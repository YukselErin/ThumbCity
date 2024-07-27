using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSupply : MonoBehaviour
{

    GunPlaceableObject gunPlaceableObject;
    public GameObject supplyObjectPrefab;
    GameObject spawnedObject;
    public bool allowSpawn = true;
    void Start()
    {
        if (allowSpawn)
        {
            SpawnNew();
        }
    }

    // Update is called once per frame
    void ItemPickedUp()
    {
        gunPlaceableObject.attachedEvent.RemoveListener(ItemPickedUp);
        Invoke("SpawnNew", 5f);
    }
    public void SpawnNew()
    {

        if (gunPlaceableObject != null)
        {
            gunPlaceableObject.attachedEvent.RemoveListener(ItemPickedUp);
        }
        spawnedObject = Instantiate(supplyObjectPrefab, transform);
        gunPlaceableObject = spawnedObject.GetComponentInChildren<GunPlaceableObject>();
        gunPlaceableObject.attachedEvent.AddListener(ItemPickedUp);
    }
}
