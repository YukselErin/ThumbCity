using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbowl : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 vector3;
    void Start()
    {
vector3 = fishpoint.position;
    }
    Fish fish;
    public Transform fishpoint;
    GunPlaceableObject gunPlaceableObject;
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Fish>(out fish))
        {
            collider.gameObject.TryGetComponent(out gunPlaceableObject);
            if (gunPlaceableObject.gunTipPlacement == null)
            {
                fish.GetComponent<Rigidbody>().isKinematic = true;
                fish.transform.position = fishpoint.transform.position;
                fish.transform.parent.position = fishpoint.transform.position;
                fish.transform.parent.SetParent(fishpoint,true);
                //StartCoroutine(fishspin());
            }
        }
        
    }
    void Update(){
        fishpoint.position = vector3;
    }
    IEnumerator fishspin()
    {
        while (gunPlaceableObject.gunTipPlacement == null)
        {
           // fishpoint.Rotate(new Vector3(1f, 0f, 0f));
            yield return null;
        }
        StopAllCoroutines();
    }
}
