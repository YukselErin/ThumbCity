using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : ObjectShootAction
{
    // Start is called before the first frame update
    public float force = 10f;
    Light light;
    public override void Shoot()
    {
        transform.parent.SetParent(null);
        rb.isKinematic = false;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        light.enabled = true;
        goonController.shoot();
    }

    Rigidbody rb;
    GoonController goonController;
    void Awake()
    {
        light = GetComponent<Light>();
        rb = GetComponent<Rigidbody>();
        goonController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GoonController>();
    }
    public GameObject explosion;

}
