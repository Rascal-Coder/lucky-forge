using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

// A new local save backend for the offline rebuild. The envelope is NOT ES3's
// original encrypted format. It deliberately writes into an isolated subfolder.
public static class OfflineKeyStore
{
    private sealed class State { public Dictionary<string, JToken> values = new Dictionary<string, JToken>(StringComparer.Ordinal); public bool dirty; }
    private sealed class Envelope { public int format = 1; public string payload; public string sha256; }
    private static readonly object Gate = new object();
    private static readonly Dictionary<string, State> States = new Dictionary<string, State>(StringComparer.OrdinalIgnoreCase);
    private static string verificationRoot;
    private static readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.None,
        DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
        DateParseHandling = DateParseHandling.DateTime,
        ObjectCreationHandling = ObjectCreationHandling.Replace,
        ReferenceLoopHandling = ReferenceLoopHandling.Error,
        Converters = { new AssetConverter() }
    });

    public static string PathFor(string filePath = null, ES3Settings settings = null)
    {
        string logical = !string.IsNullOrEmpty(filePath) ? filePath : settings != null && !string.IsNullOrEmpty(settings.path) ? settings.path : "medupac.es3";
        string name = Path.GetFileName(logical);
        foreach (char c in Path.GetInvalidFileNameChars()) name = name.Replace(c, '_');
        string root = verificationRoot ?? Path.Combine(Application.persistentDataPath, "OfflineRecovery");
        return Path.Combine(root, name + "." + Digest(logical).Substring(0, 12) + ".offline.json");
    }

    private static string Digest(string value)
    {
        using (var sha = SHA256.Create()) return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "").ToLowerInvariant();
    }

    private static Dictionary<string, JToken> ReadVerified(string path)
    {
        var envelope = JsonConvert.DeserializeObject<Envelope>(File.ReadAllText(path, Encoding.UTF8));
        if (envelope == null || envelope.format != 1 || envelope.payload == null || !StringComparer.Ordinal.Equals(Digest(envelope.payload), envelope.sha256))
            throw new InvalidDataException("Offline save envelope or checksum is invalid.");
        var data = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(envelope.payload);
        if (data == null) throw new InvalidDataException("Offline save payload is missing.");
        return new Dictionary<string, JToken>(data, StringComparer.Ordinal);
    }

    private static State Get(string path)
    {
        State state;
        if (States.TryGetValue(path, out state)) return state;
        state = new State();
        Exception failure = null;
        if (File.Exists(path))
        {
            try { state.values = ReadVerified(path); }
            catch (Exception ex) when (ex is InvalidDataException || ex is IOException || ex is JsonException || ex is FormatException) { failure = ex; }
        }
        else if (File.Exists(path + ".bak"))
        {
            state.values = ReadVerified(path + ".bak");
            state.dirty = true;
        }
        if (failure != null)
        {
            if (!File.Exists(path + ".bak")) throw new InvalidDataException("Offline save is invalid and no backup exists.", failure);
            state.values = ReadVerified(path + ".bak");
            state.dirty = true;
        }
        States[path] = state;
        return state;
    }

    private static bool WriteThrough(ES3Settings settings)
    {
        return settings != null && settings.location != ES3.Location.Cache;
    }

    public static void Save<T>(string key, T value, string filePath = null, ES3Settings settings = null)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        lock (Gate)
        {
            string path = PathFor(filePath, settings);
            var state = Get(path);
            state.values[key] = value == null ? JValue.CreateNull() : JToken.FromObject(value, Serializer);
            state.dirty = true;
            if (WriteThrough(settings)) FlushPath(path, state);
        }
    }

    public static T Load<T>(string key, bool hasDefault, T defaultValue, string filePath = null, ES3Settings settings = null)
    {
        lock (Gate)
        {
            JToken token;
            if (!Get(PathFor(filePath, settings)).values.TryGetValue(key, out token))
            {
                if (hasDefault) return defaultValue;
                throw new KeyNotFoundException("The offline save key was not found: " + key);
            }
            if (token == null || token.Type == JTokenType.Null) return default(T);
            return token.ToObject<T>(Serializer);
        }
    }

    public static void LoadInto(string key, object obj, string filePath = null, ES3Settings settings = null)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        lock (Gate)
        {
            JToken token;
            if (!Get(PathFor(filePath, settings)).values.TryGetValue(key, out token)) throw new KeyNotFoundException(key);
            using (var reader = token.CreateReader()) Serializer.Populate(reader, obj);
        }
    }

    public static byte[] SerializeValue<T>(T value)
    {
        lock (Gate) return Encoding.UTF8.GetBytes((value == null ? JValue.CreateNull() : JToken.FromObject(value, Serializer)).ToString(Formatting.None));
    }

    public static T DeserializeValue<T>(byte[] bytes)
    {
        if (bytes == null) throw new ArgumentNullException(nameof(bytes));
        lock (Gate) return JToken.Parse(Encoding.UTF8.GetString(bytes)).ToObject<T>(Serializer);
    }

    public static bool KeyExists(string key, string filePath = null, ES3Settings settings = null)
    { lock (Gate) return Get(PathFor(filePath, settings)).values.ContainsKey(key); }

    public static string[] GetKeys(string filePath = null, ES3Settings settings = null)
    { lock (Gate) return Get(PathFor(filePath, settings)).values.Keys.ToArray(); }

    public static void DeleteKey(string key, string filePath = null, ES3Settings settings = null)
    {
        lock (Gate)
        {
            string path = PathFor(filePath, settings); var state = Get(path);
            if (state.values.Remove(key)) state.dirty = true;
            if (WriteThrough(settings)) FlushPath(path, state);
        }
    }

    public static bool FileExists(string filePath = null, ES3Settings settings = null)
    {
        lock (Gate)
        {
            string path = PathFor(filePath, settings); State state;
            if (settings == null || settings.location == ES3.Location.Cache)
                if (States.TryGetValue(path, out state) && state.values.Count > 0) return true;
            return File.Exists(path) || File.Exists(path + ".bak");
        }
    }

    public static void DeleteFile(string filePath = null, ES3Settings settings = null)
    {
        lock (Gate)
        {
            string path = PathFor(filePath, settings); States.Remove(path);
            foreach (string suffix in new[] { "", ".bak", ".tmp" }) if (File.Exists(path + suffix)) File.Delete(path + suffix);
        }
    }

    public static void CacheFile(string filePath = null, ES3Settings settings = null)
    { lock (Gate) Get(PathFor(filePath, settings)); }

    public static void StoreCachedFile(string filePath = null, ES3Settings settings = null)
    { lock (Gate) { string path = PathFor(filePath, settings); FlushPath(path, Get(path)); } }

    public static void FlushAll()
    { lock (Gate) foreach (var entry in States) if (entry.Value.dirty) FlushPath(entry.Key, entry.Value); }

    private static void FlushPath(string path, State state)
    {
        if (!state.dirty && File.Exists(path)) return;
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        string payload = JsonConvert.SerializeObject(state.values, Formatting.None);
        var envelope = new Envelope { payload = payload, sha256 = Digest(payload) };
        byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(envelope, Formatting.None));
        string temp = path + ".tmp";
        using (var stream = new FileStream(temp, FileMode.Create, FileAccess.Write, FileShare.None))
        { stream.Write(bytes, 0, bytes.Length); stream.Flush(true); }
        if (File.Exists(path))
        {
            // Keep the last verified predecessor. A corrupt primary must not replace a good backup.
            bool primaryValid;
            try { ReadVerified(path); primaryValid = true; } catch { primaryValid = false; }
            if (primaryValid) File.Copy(path, path + ".bak", true);
            File.Replace(temp, path, null);
        }
        else File.Move(temp, path);
        state.dirty = false;
    }

    // Verification intentionally keeps files under a caller-selected test folder.
    // Do not call while a real gameplay session has dirty cached state.
    public static void SetVerificationRoot(string absoluteDirectory)
    {
        lock (Gate)
        {
            if (absoluteDirectory != null && !Path.IsPathRooted(absoluteDirectory)) throw new ArgumentException("An absolute verification root is required.");
            verificationRoot = absoluteDirectory;
            States.Clear();
        }
    }
    public static void ResetMemoryForVerification() { lock (Gate) States.Clear(); }

    private sealed class AssetConverter : JsonConverter
    {
        public override bool CanConvert(Type type) { return typeof(UnityEngine.Object).IsAssignableFrom(type); }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var asset = value as UnityEngine.Object;
            if (asset == null) { writer.WriteNull(); return; }
            var token = new JObject { ["$unity"] = OfflineAssetReferenceCatalog.GuidFor(asset), ["type"] = asset.GetType().FullName, ["name"] = asset.name };
            token.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var token = JObject.Load(reader);
            return OfflineAssetReferenceCatalog.Resolve((string)token["$unity"], type);
        }
    }
}
