using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnding : MonoBehaviour
{
    RippleHandler rippleHandler;
    public AudioSource audioSource;
    public AudioClip gunshot;
    public AudioClip thunk;

    void Start()
    {
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        rippleHandler.currentStory.BindExternalFunction("JonathanKillsHimself", () =>
       {
           KYS();
       });
    }

    // Update is called once per frame
    void KYS()
    {
        Invoke("gunShot", 0f);
        Invoke("Thunk", 1f);

    }
    void gunShot() { audioSource.PlayOneShot(gunshot); }
    void Thunk() { audioSource.PlayOneShot(thunk); }
}
