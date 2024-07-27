using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deal : MonoBehaviour
{

    RippleHandler rippleHandler;
    void Start()
    {
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        rippleHandler.currentStory.BindExternalFunction("spawnFlares", () => { SpawnFlares(); });
    }

    // Update is called once per frame
    void SpawnFlares()
    {
        GetComponent<ItemSupply>().SpawnNew();
    }
}
