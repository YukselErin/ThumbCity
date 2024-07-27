using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : ObjectShootAction
{
    // Start is called before the first frame update
    public float force = 10f;

    public override void Shoot()
    {
        primed = true;
        transform.parent.SetParent(null);
        rb.isKinematic = false;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public GameObject explosion;
    public GameObject explosionInstance;
    public bool primed = false;
    void destroyExp()
    {
        Destroy(explosionInstance);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (explosion != null)
        {
            if (primed)
            {
                explosionInstance = Instantiate(explosion);
                explosionInstance.transform.position = transform.position;
                Destroy(gameObject);
                Invoke("destroyExp", 1f);
            }
            else if (collision.collider.tag == "Bullet")
            {
                explosionInstance = Instantiate(explosion);
                explosionInstance.transform.position = transform.position;
                Destroy(gameObject);
                Invoke("destroyExp", 1f);
            }
        }

    }
}
