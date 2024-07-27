using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : ObjectShootAction
{
    // Start is called before the first frame update
    Animator animator;
    public float force = 10f;
    public bool catHappy = false;
    GunPlaceableObject gunPlaceableObject;
    CatHead catHead;
    int attachID;
    void Start()
    {
        gunPlaceableObject = GetComponent<GunPlaceableObject>();
        gunPlaceableObject.attachedEvent.AddListener(detach);
        animator = GetComponentInChildren<Animator>();
        attachID = Animator.StringToHash("Attached");
        InvokeRepeating("meow", 5f, 5f);
    }
    void meow()
    {
        audioSource.PlayOneShot(meowClip);
    }
    public override void Shoot()
    {
        rb = transform.parent.gameObject.GetComponentInChildren<Rigidbody>();
        transform.parent.SetParent(null, true);
        rb.isKinematic = false;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    Rigidbody rb;
    RippleHandler rippleHandler;
    void Awake()
    {
    }
    public GameObject explosion;
    Cattachable cattachableScript;
    void OnCollisionEnter(Collision collision)
    {
        if(cattachableScript){
            detach();
        }
        if (collision.collider.TryGetComponent(out cattachableScript))
        {
            if (!cattachableScript.cattached)
            {
                rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
                rb.isKinematic = true;
                transform.position = cattachableScript.neck.position;
                transform.rotation = cattachableScript.neck.rotation;
                transform.parent.SetParent(collision.transform, true);

                cattachableScript.cattached = true;
                rippleHandler.setBool(cattachableScript.attachedString, true);
                rippleHandler.setBool(cattachableScript.toxoplosmosisString, catHappy);
                animator.SetBool(attachID, true);

            }

        }
    }
    public AudioSource audioSource;
    public AudioClip meowClip;
    void detach()
    {
        if (cattachableScript != null)
        {
            Debug.Log(cattachableScript.gameObject);
            rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();

            if (cattachableScript != null) cattachableScript.cattached = false;
            rippleHandler.setBool(cattachableScript.attachedString, false);
            rippleHandler.setBool(cattachableScript.toxoplosmosisString, false);
            animator.SetBool(attachID, false);
        }

    }
    public void FedFish()
    {
        catHappy = true;
        audioSource.PlayOneShot(meowClip);

    }
}
