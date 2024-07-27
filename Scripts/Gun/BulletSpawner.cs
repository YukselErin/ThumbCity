using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    public ObjectPool<GameObject> _pool;
    Shoot shootScript;
    void Start()
    {
        shootScript = GetComponent<Shoot>();
        _pool = new ObjectPool<GameObject>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool, OnDestroyBullet, true, 10, 100);
    }
    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(0f, 0f, 0f), quaternion.identity);
        bullet.GetComponent<Bullet>().SetPool(_pool);
        return bullet;
    }
    
    private void OnTakeBulletFromPool(GameObject bullet)
    {
        bullet.gameObject.SetActive(true);
    }
    private void OnReturnBulletToPool(GameObject bullet)
    {
        bullet.gameObject.SetActive(false);

    }
    private void OnDestroyBullet(GameObject bullet)
    {
        Destroy(bullet);
    }
}
