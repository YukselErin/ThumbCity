using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoonShooter : MonoBehaviour
{
    BulletSpawner bulletSpawner;
    public Transform dozerTransform;

    void Start()
    {
        bulletSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BulletSpawner>();
        shootCooldown = 60f / bulletRPM;
    }

    public float bulletRPM = 100;
    float shootCooldown;
    float lastTimeShot = 0f;
    GameObject shootingBullet;
    public Transform bulletOrigin;
    public float bulletforce = 5f;
    public float burstRPM = 10;
    float burstCooldown;
    float lastBurst = 0f;
    public float bulletPerBurst = 10f;
    float burst = 0f;
    void Update()
    {
        burstCooldown = 60f / burstRPM;
        if (lastBurst + burstCooldown < Time.time)
        {
            shootCooldown = 60f / bulletRPM;                    //Move to start
            if (lastTimeShot + shootCooldown < Time.time)
            {
                bulletOrigin.LookAt(dozerTransform);
                lastTimeShot = Time.time;
                shootingBullet = bulletSpawner._pool.Get();
                shootingBullet.transform.position = bulletOrigin.position;
                shootingBullet.transform.rotation = quaternion.identity;
                shootingBullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                shootingBullet.GetComponent<Rigidbody>().AddForce(bulletOrigin.forward * bulletforce, ForceMode.Impulse);
                burst++;
            }

            if (burst > bulletPerBurst)
            {
                lastBurst = Time.time;
                burst = 0f;
            }
        }

    }
}
