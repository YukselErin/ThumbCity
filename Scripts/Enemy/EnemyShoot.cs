using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject[] shootOrigins;
    BulletSpawner bulletSpawner;
    Transform playerTransform;
    RippleHandler dialogueHandler;
    public GameObject triggerCollider;
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        bulletSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<BulletSpawner>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        dialogueHandler.currentStory.BindExternalFunction("talkedVetDisarm", () =>
        {
            enabled = false;
            triggerCollider.SetActive(false);
        });
    }

    GameObject shootingBullet;
    public float bulletforce = 10f;
    public void Shoot()
    {
        foreach (GameObject origin in shootOrigins)
        {
            shootingBullet = bulletSpawner._pool.Get();
            shootingBullet.transform.position = origin.transform.position;
            shootingBullet.transform.rotation = quaternion.identity;
            shootingBullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            shootingBullet.GetComponent<Rigidbody>().AddForce(origin.transform.forward * bulletforce, ForceMode.Impulse);
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
