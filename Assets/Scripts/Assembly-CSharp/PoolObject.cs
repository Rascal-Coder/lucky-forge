// Offline reconstruction candidate from original Lucky Forge1.49.9 ARM64.
// See ../runtime-recovery.txt for source ranges and unvalidated edge behavior.
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [Serializable]
    public class Pool { public string tag; public GameObject prefab; public int size; }
    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    public WarController warController;
    public List<ProjectilePool> Projectilepools;
    private Dictionary<string, Queue<Projectile>> ProjectilePoolDictionary;
    public List<SkillProjectilePool> SkillProjectilePools;
    private Dictionary<string, Queue<SkillProjectile>> SkillProjectilePoolDictionary;
    private bool started;

    // RVA0x2023d30. Original callers must decide when to activate; OnEnable does not initialize.
    public void ActivatePool()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject item = Instantiate(pool.prefab, transform);
                item.name = pool.tag;
                item.SetActive(false);
                queue.Enqueue(item);
            }
            poolDictionary.Add(pool.tag, queue);
        }
        ProjectilePoolDictionary = new Dictionary<string, Queue<Projectile>>();
        foreach (ProjectilePool pool in Projectilepools)
        {
            Queue<Projectile> queue = new Queue<Projectile>();
            for (int i = 0; i < pool.size; i++)
            {
                Projectile item = Instantiate(pool.prefab, transform);
                item.name = pool.tag;
                item.gameObject.SetActive(false);
                queue.Enqueue(item);
            }
            ProjectilePoolDictionary.Add(pool.tag, queue);
        }
        SkillProjectilePoolDictionary = new Dictionary<string, Queue<SkillProjectile>>();
        foreach (SkillProjectilePool pool in SkillProjectilePools)
        {
            Queue<SkillProjectile> queue = new Queue<SkillProjectile>();
            for (int i = 0; i < pool.size; i++)
            {
                SkillProjectile item = Instantiate(pool.prefab, transform);
                item.name = pool.tag;
                item.gameObject.SetActive(false);
                queue.Enqueue(item);
            }
            SkillProjectilePoolDictionary.Add(pool.tag, queue);
        }
        started = true;
    }

    // RVA0x202459c. Preserve queue enumeration/order and activation conditions.
    private void OnEnable()
    {
        if (!started) return;
        foreach (KeyValuePair<string, Queue<GameObject>> pair in poolDictionary)
            foreach (GameObject item in pair.Value)
                if (item.activeInHierarchy) { item.SetActive(false); poolDictionary[pair.Key].Enqueue(item); }
        foreach (KeyValuePair<string, Queue<Projectile>> pair in ProjectilePoolDictionary)
            foreach (Projectile item in pair.Value)
                if (item.gameObject.activeInHierarchy) { item.gameObject.SetActive(false); ProjectilePoolDictionary[pair.Key].Enqueue(item); }
        foreach (KeyValuePair<string, Queue<SkillProjectile>> pair in SkillProjectilePoolDictionary)
            foreach (SkillProjectile item in pair.Value)
                if (item.gameObject.activeInHierarchy) { item.gameObject.SetActive(false); SkillProjectilePoolDictionary[pair.Key].Enqueue(item); }
    }

    // RVA0x2024f18: only projectile dictionary, not skill-projectile dictionary.
    public void ProjectilePoolaDondur()
    {
        foreach (KeyValuePair<string, Queue<Projectile>> pair in ProjectilePoolDictionary)
            foreach (Projectile item in pair.Value)
                if (item.gameObject.activeInHierarchy) { item.gameObject.SetActive(false); ProjectilePoolDictionary[pair.Key].Enqueue(item); }
    }

    // RVA0x2025274. Normal queue checks current Count repeatedly (unbounded active rotation).
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, bool bossmu = false, bool dontspawn = false)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError("SpawnFromPool: poolDictionary does not contain tag '" + tag + "'");
            return null;
        }
        GameObject item = null;
        while (poolDictionary[tag].Count > 0)
        {
            GameObject candidate = poolDictionary[tag].Dequeue();
            if (candidate == null) continue;
            if (!candidate.activeInHierarchy) { item = candidate; break; }
            poolDictionary[tag].Enqueue(candidate);
        }
        if (item == null)
        {
            Pool pool = pools.Find(p => p.tag == tag);
            if (pool == null || pool.prefab == null)
            {
                Debug.LogError("SpawnFromPool: Prefab missing for tag '" + tag + "'");
                return null;
            }
            item = Instantiate(pool.prefab, transform);
            item.name = tag;
        }
        if (item == null) { Debug.LogError("SpawnFromPool: objectToSpawn is STILL null!"); return null; }
        item.transform.position = position;
        item.transform.rotation = rotation;
        if (!dontspawn) item.SetActive(true);
        if (bossmu)
        {
            if (warController == null) { Debug.LogError("SpawnFromPool: warController is NULL!"); return item; }
            Enemy enemy = item.GetComponent<Enemy>();
            if (enemy != null) warController.bossvarsa = enemy;
            else Debug.LogWarning("SpawnFromPool: Boss prefab '" + tag + "' has no Enemy component!");
            warController.bossgeliyor = true;
            if (warController.BossSlider != null) warController.BossSlider.gameObject.SetActive(true);
            else Debug.LogWarning("SpawnFromPool: BossSlider is NULL!");
        }
        return item;
    }

    // RVA0x20258dc. Missing dictionary tag is a no-op.
    public void ReturnToPool(string tag, GameObject objectToReturn)
    {
        if (poolDictionary.ContainsKey(tag)) { objectToReturn.SetActive(false); poolDictionary[tag].Enqueue(objectToReturn); }
    }

    // RVA0x2021274. Projectile search rotates at most the captured initial Count.
    public Projectile SpawnProjectile(string tag, Vector3 position, Quaternion rotation)
    {
        if (!ProjectilePoolDictionary.ContainsKey(tag)) return null;
        Projectile item = null;
        int attempts = ProjectilePoolDictionary[tag].Count;
        for (int i = 0; i < attempts; i++)
        {
            Projectile candidate = ProjectilePoolDictionary[tag].Dequeue();
            if (!candidate.gameObject.activeInHierarchy) { item = candidate; break; }
            ProjectilePoolDictionary[tag].Enqueue(candidate);
        }
        if (item == null)
        {
            ProjectilePool pool = Projectilepools.Find(p => p.tag == tag);
            if (pool == null) return null;
            item = Instantiate(pool.prefab, transform);
            item.name = tag;
            ProjectilePoolDictionary[tag].Enqueue(item);
        }
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.gameObject.SetActive(true);
        return item;
    }

    // RVA recorded in additional-disassembly/PoolObject__ReturnToProjectilePool*.asm.
    public void ReturnToProjectilePool(string tag, Projectile projectile)
    {
        if (ProjectilePoolDictionary.ContainsKey(tag)) { projectile.gameObject.SetActive(false); ProjectilePoolDictionary[tag].Enqueue(projectile); }
    }

    public SkillProjectile SpawnSkillProjectile(string tag, Vector3 position, Quaternion rotation)
    {
        if (!SkillProjectilePoolDictionary.ContainsKey(tag)) return null;
        SkillProjectile item = null;
        int attempts = SkillProjectilePoolDictionary[tag].Count;
        for (int i = 0; i < attempts; i++)
        {
            SkillProjectile candidate = SkillProjectilePoolDictionary[tag].Dequeue();
            if (!candidate.gameObject.activeInHierarchy) { item = candidate; break; }
            SkillProjectilePoolDictionary[tag].Enqueue(candidate);
        }
        if (item == null)
        {
            SkillProjectilePool pool = SkillProjectilePools.Find(p => p.tag == tag);
            if (pool == null) return null;
            item = Instantiate(pool.prefab, transform);
            item.name = tag;
            SkillProjectilePoolDictionary[tag].Enqueue(item);
        }
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.gameObject.SetActive(true);
        return item;
    }

    public void ReturnToSkillProjectilePool(string tag, SkillProjectile skillProjectile)
    {
        if (SkillProjectilePoolDictionary.ContainsKey(tag)) { skillProjectile.gameObject.SetActive(false); SkillProjectilePoolDictionary[tag].Enqueue(skillProjectile); }
    }
}
