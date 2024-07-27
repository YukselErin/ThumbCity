using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    ObjectPool<GameObject> _pool;
    BulletSpawner _bulletSpawnerScript;
    public int bounceAmount = 0;
    public void SetPool(ObjectPool<GameObject> pool)
    {
        _pool = pool;

    }
    void Start()
    {
        DestroyBullet = StartCoroutine(DeactivateBulletAfterTime());
        audioSource = GetComponent<AudioSource>();
    }



    void Awake()
    {


    }
    void OnEnable()
    {
        DestroyBullet = StartCoroutine(DeactivateBulletAfterTime());
        released = false;
    }
    bool released = false;
    AudioSource audioSource;
    public AudioClip[] ricochet;
    public AudioClip[] whizBy;
    void OnCollisionEnter(Collision collision)
    {
        bounceAmount++;
        audioSource.PlayOneShot(ricochet[Random.Range(0, ricochet.Length)]);
        if (bounceAmount > 2)
        {
            bounceAmount = 0;
            if (!released) { _pool.Release(this.gameObject); released = true; }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "player")
        {
            audioSource.PlayOneShot(whizBy[Random.Range(0, whizBy.Length)]);
        }
    }
    private Coroutine DestroyBullet;
    float destroyTime = 10f;
    private IEnumerator DeactivateBulletAfterTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < destroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        bounceAmount = 0;
        if (!released) { _pool.Release(this.gameObject); released = true; }
    }
}