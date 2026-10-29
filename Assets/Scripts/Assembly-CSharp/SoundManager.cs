using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	public AudioMixer _mixer;

	public AudioSource efxSource;

	public AudioSource musicSource;

	public AudioSource CashSource;

	public AudioSource YerSource;

	public AudioSource AmbianceSource;

	public AudioSource AmbianceSourceEfx;

	public AudioSource SahneSoundsSource;

	public static SoundManager instance;

	public float lowPitchRange = 0.99f;

	public float highPitchRange = 1.01f;

	public static AudioClip _click;

	public static AudioClip _yemek;

	public static AudioClip _coin;

	public static AudioClip _coin2;

	public static AudioClip _muzik;

	public static AudioClip _lobby;

	public static AudioClip _su;

	public static AudioClip _selam;

	public static AudioClip _bell;

	public static AudioClip _bell2;

	public static AudioClip _buble;

	public static AudioClip _close;

	public static AudioClip _bass;

	public static AudioClip _upgrade;

	public static AudioClip _upgrade2;

	public static AudioClip _crystal;

	public static AudioClip _gecis;

	public static AudioClip _clap;

	public static AudioClip _kasiyer;

	public static AudioClip _fuze;

	public static AudioClip _luckyforge;

	public static AudioClip _finded;

	public static AudioClip _splash;

	public static AudioClip _oltaat;

	public static AudioClip _anchor;

	public static AudioClip _balikgone;

	public static AudioClip _catch;

	public static AudioClip _ghost;

	public static AudioClip _winwin;

	public static AudioClip _collecting;

	public static AudioClip _karakterupg;

	public static AudioClip _fire;

	public static AudioClip _meteorduser;

	public static AudioClip _obelisksaldiriyor;

	public static AudioClip _bossfight;

	public static AudioClip _ingotupg;

	public static AudioClip _kirilma;

	public static AudioClip _daktilo;

	public static AudioClip _rune;

	public static AudioClip _speeduptime;

	public static AudioClip _zeustalk;

	public static AudioClip _magicwords;

	public static GameObject soundEffectYer;

	public static AudioClip freeze;

	public static AudioClip flame;

	public static AudioClip zehir;

	public static AudioClip yerevur;

	public static AudioClip obliriate;

	public static AudioClip win3x;

	public static AudioClip door;

	public static AudioClip talent;

	public static AudioClip herostone;

	public static AudioClip sonekran;

	public static AudioClip warhorn;

	public static AudioClip silvercoin;

	public static AudioClip egg;

	public static AudioClip coindrop;

	public static AudioClip die;

	public static AudioClip runes;

	public static AudioClip throwit;

	public static AudioClip sword;

	public static AudioClip earthquake;

	public static AudioClip necroattack2;

	public static AudioClip gecis2;

	public static AudioClip impactdirt;

	public static AudioClip levelup;

	private int screensh;

	private void Awake()
	{
        // Native Awake RVA0x20df820: exact Resources paths and static offsets.
        _luckyforge = Resources.Load<AudioClip>("Music/luckyforge"); // 0x20dfb94 -> 0x20dfba4
        sword = Resources.Load<AudioClip>("Music/sword"); // 0x20dfbb8 -> 0x20dfbc8
        throwit = Resources.Load<AudioClip>("Music/throw"); // 0x20dfbdc -> 0x20dfbec
        runes = Resources.Load<AudioClip>("Music/runes"); // 0x20dfc00 -> 0x20dfc10
        die = Resources.Load<AudioClip>("Music/die"); // 0x20dfc24 -> 0x20dfc34
        egg = Resources.Load<AudioClip>("Music/waterpos"); // 0x20dfc48 -> 0x20dfc58
        coindrop = Resources.Load<AudioClip>("Music/coindrop"); // 0x20dfc6c -> 0x20dfc7c
        silvercoin = Resources.Load<AudioClip>("Music/silvercoin"); // 0x20dfc98 -> 0x20dfca8
        warhorn = Resources.Load<AudioClip>("Music/warhorn"); // 0x20dfcc4 -> 0x20dfcd4
        talent = Resources.Load<AudioClip>("Music/talent"); // 0x20dfcf0 -> 0x20dfd00
        herostone = Resources.Load<AudioClip>("Music/herostone"); // 0x20dfd1c -> 0x20dfd2c
        sonekran = Resources.Load<AudioClip>("Music/sonekran"); // 0x20dfd48 -> 0x20dfd58
        door = Resources.Load<AudioClip>("Music/door"); // 0x20dfd74 -> 0x20dfd84
        freeze = Resources.Load<AudioClip>("Music/godof/hitground"); // 0x20dfda0 -> 0x20dfdb0
        flame = Resources.Load<AudioClip>("Music/throw"); // 0x20dfdc4 -> 0x20dfdd4
        zehir = Resources.Load<AudioClip>("Music/godof/zehir"); // 0x20dfdf0 -> 0x20dfe00
        yerevur = Resources.Load<AudioClip>("Music/godof/yerevur"); // 0x20dfe1c -> 0x20dfe2c
        obliriate = Resources.Load<AudioClip>("Music/godof/obliriate"); // 0x20dfe48 -> 0x20dfe58
        win3x = Resources.Load<AudioClip>("Music/win3x"); // 0x20dfe74 -> 0x20dfe84
        _daktilo = Resources.Load<AudioClip>("Music/daktilo"); // 0x20dfea0 -> 0x20dfeb0
        _click = Resources.Load<AudioClip>("Music/click5"); // 0x20dfecc -> 0x20dfedc
        _coin = Resources.Load<AudioClip>("Music/coin"); // 0x20dfef8 -> 0x20dff08
        _yemek = Resources.Load<AudioClip>("Music/kazi2"); // 0x20dff24 -> 0x20dff34
        _su = Resources.Load<AudioClip>("Music/spin"); // 0x20dff50 -> 0x20dff60
        _selam = Resources.Load<AudioClip>("Music/close"); // 0x20dff7c -> 0x20dff8c
        _bell = Resources.Load<AudioClip>("Music/impact"); // 0x20dffa8 -> 0x20dffb8
        _buble = Resources.Load<AudioClip>("Music/buble"); // 0x20dffd4 -> 0x20dffe4
        _close = Resources.Load<AudioClip>("Music/close2"); // 0x20e0000 -> 0x20e0010
        _muzik = Resources.Load<AudioClip>("Music/music"); // 0x20e002c -> 0x20e003c
        _lobby = Resources.Load<AudioClip>("Music/musiclobby"); // 0x20e0058 -> 0x20e0068
        _bass = Resources.Load<AudioClip>("Music/chest"); // 0x20e0084 -> 0x20e0094
        _crystal = Resources.Load<AudioClip>("Music/collectunlock"); // 0x20e00b0 -> 0x20e00c0
        _upgrade = Resources.Load<AudioClip>("Music/upgrade"); // 0x20e00dc -> 0x20e00ec
        _upgrade2 = Resources.Load<AudioClip>("Music/upgrade2"); // 0x20e0108 -> 0x20e0118
        _gecis = Resources.Load<AudioClip>("Music/godof/harpyhit"); // 0x20e0134 -> 0x20e0144
        _clap = Resources.Load<AudioClip>("Music/clap"); // 0x20e0160 -> 0x20e0170
        _kasiyer = Resources.Load<AudioClip>("Music/meteorduser"); // 0x20e018c -> 0x20e019c
        _coin2 = Resources.Load<AudioClip>("Music/coin2"); // 0x20e01b8 -> 0x20e01c8
        _bell2 = Resources.Load<AudioClip>("Music/ring2"); // 0x20e01e4 -> 0x20e01f4
        _finded = Resources.Load<AudioClip>("Music/collectunlock"); // 0x20e0208 -> 0x20e0218
        _splash = Resources.Load<AudioClip>("Music/bell"); // 0x20e0234 -> 0x20e0244
        _oltaat = Resources.Load<AudioClip>("Music/dindir"); // 0x20e0260 -> 0x20e0270
        _anchor = Resources.Load<AudioClip>("Music/kazi"); // 0x20e028c -> 0x20e029c
        _balikgone = Resources.Load<AudioClip>("Music/bass"); // 0x20e02b8 -> 0x20e02c8
        _catch = Resources.Load<AudioClip>("Music/arrow"); // 0x20e02e4 -> 0x20e02f4
        _fuze = Resources.Load<AudioClip>("Music/meteorshower"); // 0x20e0310 -> 0x20e0320
        _rune = Resources.Load<AudioClip>("Music/godof/runes"); // 0x20e033c -> 0x20e034c
        _ingotupg = Resources.Load<AudioClip>("Music/godof/ingotspend"); // 0x20e0368 -> 0x20e0378
        _kirilma = Resources.Load<AudioClip>("Music/godof/relicbreking"); // 0x20e0394 -> 0x20e03a4
        _karakterupg = Resources.Load<AudioClip>("Music/godof/obliriate"); // 0x20e03b8 -> 0x20e03c8
        _fire = Resources.Load<AudioClip>("Music/swing"); // 0x20e03e4 -> 0x20e03f4
        _meteorduser = Resources.Load<AudioClip>("Music/groundcrush"); // 0x20e0410 -> 0x20e0420
        _obelisksaldiriyor = Resources.Load<AudioClip>("Music/obelisksaldiri"); // 0x20e043c -> 0x20e044c
        _ghost = Resources.Load<AudioClip>("Music/godof/ghost"); // 0x20e0468 -> 0x20e0478
        _winwin = Resources.Load<AudioClip>("Music/winwin"); // 0x20e0494 -> 0x20e04a4
        _collecting = Resources.Load<AudioClip>("Music/collectunlock"); // 0x20e04b8 -> 0x20e04c8
        _zeustalk = Resources.Load<AudioClip>("Music/godof/zeustalk"); // 0x20e04e4 -> 0x20e04f4
        _speeduptime = Resources.Load<AudioClip>("Music/godof/speeduptime"); // 0x20e0510 -> 0x20e0520
        _magicwords = Resources.Load<AudioClip>("Music/hitenemy"); // 0x20e053c -> 0x20e054c
        earthquake = Resources.Load<AudioClip>("Music/winyay"); // 0x20e0568 -> 0x20e0578
        necroattack2 = Resources.Load<AudioClip>("Music/necroattack2"); // 0x20e0594 -> 0x20e05a4
        gecis2 = Resources.Load<AudioClip>("Music/godof/gecis"); // 0x20e05c0 -> 0x20e05d0
        impactdirt = Resources.Load<AudioClip>("Music/impactdirt"); // 0x20e05ec -> 0x20e05fc
        levelup = Resources.Load<AudioClip>("Music/levelup"); // 0x20e0618 -> 0x20e0628
        // Native does not initialize _bossfight or soundEffectYer here.
        transform.SetParent(null);
        if (instance == null) instance = this;
        else if (instance != this) { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
	}

	public void PlaySingle(AudioClip clip)
	{
        // RVA0x20e0758: deliberately plays the same clip through both channels.
        // Null-source/clip checks are resilience adaptations for recovered assets.
        if (efxSource != null) { efxSource.clip = clip; if (clip != null) efxSource.Play(); }
        if (CashSource != null) { CashSource.clip = clip; if (clip != null) CashSource.Play(); }
	}

	public void BackgroundMusic(params AudioClip[] clips)
	{
        // RVA0x20e07b8: MuzikOnOf=true is the mute/Stop branch.
        if (musicSource == null || clips == null || clips.Length == 0) return;
        if (!MenuGeneralSettings.MuzikOnOf)
        {
            int clipIndex = Random.Range(0, clips.Length);
            musicSource.pitch = Random.Range(1, 1); // original integer Range(1,1)
            musicSource.clip = clips[clipIndex];
            if (musicSource.clip != null) musicSource.Play();
        }
        if (MenuGeneralSettings.MuzikOnOf)
        {
            musicSource.clip = clips[Random.Range(0, clips.Length)];
            musicSource.Stop();
        }
	}

	public void stopBackgroundMusic()
	{
        if (musicSource != null) musicSource.Stop(); // RVA0x20e08fc
	}

	public void RandomizeSfx(params AudioClip[] clips)
	{
        PlayRecoveredEffect(efxSource, clips, true, true, true, false, default(Vector3)); // RVA0x20d328c
	}

	public void SahneSounds(Vector3 pos, params AudioClip[] clips)
	{
        PlayRecoveredEffect(SahneSoundsSource, clips, false, false, false, true, pos); // RVA0x20e0914
	}

	public void AmbienceSfx(params AudioClip[] clips)
	{
        PlayRecoveredEffect(AmbianceSource, clips, false, false, true, false, default(Vector3)); // RVA0x20e0b60
	}

	public void AmbienceEffectSfx(params AudioClip[] clips)
	{
        PlayRecoveredEffect(AmbianceSourceEfx, clips, false, false, true, false, default(Vector3)); // RVA0x20e0dec
	}

	public void CashSound(params AudioClip[] clips)
	{
        PlayRecoveredEffect(CashSource, clips, true, false, true, false, default(Vector3)); // RVA0x20e1078
	}

	public void Titret()
	{
        // Original vibration arguments; desktop has no mobile haptic device.
#if UNITY_ANDROID || UNITY_IOS
        VibrationUtils.Vibrate(80, 180);
#endif
	}

	public static void TitretStatic()
	{
        // Original vibration arguments; desktop has no mobile haptic device.
#if UNITY_ANDROID || UNITY_IOS
        VibrationUtils.Vibrate(50, 180);
#endif
	}

	public static void TitretLow()
	{
        // Original vibration arguments; desktop has no mobile haptic device.
#if UNITY_ANDROID || UNITY_IOS
        VibrationUtils.Vibrate(30, 150);
#endif
	}

	public static void TitretGuclu()
	{
        // Original vibration arguments; desktop has no mobile haptic device.
#if UNITY_ANDROID || UNITY_IOS
        VibrationUtils.Vibrate(120, 200);
#endif
	}

	public static void TitretStaticLow()
	{
        // Original vibration arguments; desktop has no mobile haptic device.
#if UNITY_ANDROID || UNITY_IOS
        VibrationUtils.Vibrate(50, 180);
#endif
	}

	public void YerSesleri(params AudioClip[] clips)
	{
        PlayRecoveredEffect(YerSource, clips, true, false, true, false, default(Vector3)); // RVA0x20e14e0
	}

    // Factored from the six native effect playback routines; preserves channel,
    // preference direction, pitch range, timeScale gating and shared particle state.
    private void PlayRecoveredEffect(AudioSource source, AudioClip[] clips,
        bool gateAtPositiveTimeScale, bool updateMixer, bool feedback,
        bool setPosition, Vector3 position)
    {
        // Original code throws on missing source/empty arrays. Recovery guard is intentional.
        if (source == null || clips == null || clips.Length == 0) return;
        if (!MenuGeneralSettings.EfektOnOf)
        {
            int clipIndex = Random.Range(0, clips.Length);
            float pitch = Random.Range(lowPitchRange, highPitchRange);
            if (!gateAtPositiveTimeScale || Time.timeScale > 0f)
            {
                source.pitch = pitch;
                source.clip = clips[clipIndex];
                if (source.clip != null) source.Play();
                if (setPosition) source.transform.position = position;
            }
            if (soundEffectYer != null) soundEffectYer.SetActive(true);
            if (updateMixer && _mixer != null) _mixer.SetFloat("MyExposedParam", -10f);
        }
        if (MenuGeneralSettings.EfektOnOf)
        {
            source.clip = clips[Random.Range(0, clips.Length)];
            source.Stop();
            if (updateMixer && _mixer != null) _mixer.SetFloat("MyExposedParam", -80f);
            if (soundEffectYer != null) soundEffectYer.SetActive(false);
        }
        if (feedback) RecoveredEffectFeedback();
    }
    private void RecoveredEffectFeedback()
    {
        // Native checks the efxSource clip (also from ambience/cash routines),
        // _bass equality OR the existence of _bell. Do not substitute the channel's clip.
        if (MenuGeneralSettings.TitresimOnOf || efxSource == null) return;
        if (efxSource.clip == _bass || _bell != null)
        {
#if UNITY_ANDROID || UNITY_IOS
            CandyCoded.HapticFeedback.HapticFeedback.MediumFeedback();
#endif
        }
    }
}
