using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fent : ObjectShootAction
{
    // Start is called before the first frame update
    public float force = 10f;

    public override void Shoot()
    {
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
    void OnCollisionEnter()
    {
        //Instantiate(explosion);
    }
}
