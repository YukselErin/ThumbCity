using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    RippleHandler rippleHandler;
    AudioSource audioSource;
    public AudioClip hit;
    public AudioClip chime;
    void Start()
    {
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        audioSource = GetComponent<AudioSource>();
    }
    Bullet bullet;
    public string NPCname;
    public GameObject death;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.transform.parent.TryGetComponent<Bullet>(out bullet))
        {
            if (bullet.bounceAmount == 1f) //bounce updates before this
            {
                if (audioSource) { audioSource.PlayOneShot(chime); }
                rippleHandler.setBool(NPCname + "Shot", true);

                ActivateRagdoll();


            }
            else
            {
                rippleHandler.setBool(NPCname + "Hit", true);
                if (audioSource) { audioSource.PlayOneShot(hit); }
            }
        }

    }
    void DeactivateBox()
    {
        GetComponent<Collider>().enabled = false;

    }
    void ActivateRagdoll()
    {
        if (death != null)
        {
            death.GetComponent<Death>().shot();
        }

    }
}
