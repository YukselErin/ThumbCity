using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip audoClip;
    Collider[] colliders;
    public float explosionRadius = 10f;
    PillarExplosion pillarExplosion;
    PlayerHealth playerHealth;
    void Start()
    {
        audiosource.PlayOneShot(audoClip);
        colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            if (col.TryGetComponent(out pillarExplosion))
            {
                pillarExplosion.exploded();
            }
            if (col.TryGetComponent(out playerHealth))
            {
                playerHealth.dealDamage(100);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
