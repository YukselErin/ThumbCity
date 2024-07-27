using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarExplosion : MonoBehaviour
{
    public BasementExplosion basementExplosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void exploded()
    {
        basementExplosion.triggerExplosion();
    }
}
