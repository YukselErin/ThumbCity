using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaceful : MonoBehaviour
{
    public DozerShooter dozerShooter;
    PlayerDozerTarget playerDozerTarget;
    RippleHandler dialogueHandler;
    // Start is called before the first frame update
    void Start()
    {

        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        playerDozerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDozerTarget>();
        dialogueHandler.currentStory.BindExternalFunction("peaceful", () =>
        {
            dozerShooter.enabled = false;
            playerDozerTarget.followable = false;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
