using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DozerShooter : MonoBehaviour
{
    BulletSpawner bulletSpawner;
    Transform playerTransform;
    PlayerDozerTarget playerDozerTarget;
    public AudioSource audioSource;
    public AudioClip gunShotClip;

    void Start()
    {
        bulletSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BulletSpawner>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerDozerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDozerTarget>();
        shootCooldown = 60f / bulletRPM;
        playerDozerTarget = playerTransform.gameObject.GetComponent<PlayerDozerTarget>();

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
    public Transform lookAt;
    public bool shootElsewhere;
    void Update()
    {
        if (playerDozerTarget.startArea || !playerDozerTarget.followable) { return; }
        Transform lookAtTarget = playerTransform;
        if (shootElsewhere) { lookAtTarget = lookAt; }
        burstCooldown = 60f / burstRPM;
        if (lastBurst + burstCooldown < Time.time)
        {
            shootCooldown = 60f / bulletRPM;                    //Move to start
            if (lastTimeShot + shootCooldown < Time.time)
            {
                bulletOrigin.LookAt(lookAtTarget);
                lastTimeShot = Time.time;
                shootingBullet = bulletSpawner._pool.Get();
                shootingBullet.transform.position = bulletOrigin.position;
                shootingBullet.transform.rotation = quaternion.identity;
                shootingBullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                shootingBullet.GetComponent<Rigidbody>().AddForce(bulletOrigin.forward * bulletforce, ForceMode.Impulse);
                audioSource.PlayOneShot(gunShotClip);
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
