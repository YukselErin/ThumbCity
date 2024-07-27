using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    GunPlaceableObject gunPlaceableObject;

    // Start is called before the first frame update
    void Start()
    {
        gunPlaceableObject = GetComponent<GunPlaceableObject>();
        gunPlaceableObject.attachedEvent.AddListener(detach);
    }

    // Update is called once per frame
    public void eaten()
    {
        Destroy(gameObject);
    }
    void detach()
    {
       
            GetComponent<AudioSource>().Play();

    }
}
