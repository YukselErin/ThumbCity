using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SaveLoadSystem;
public class GunPlaceableObject : MonoBehaviour, ISaveable
{

    public UnityEvent attachedEvent;
    public Transform attachmentPoint;
    float lastFired;
    public bool Placeable()
    {

        return Time.time > lastFired + 0.1f;

    }

    public ObjectShootAction shootScript;
    public void Shoot()
    {
        if (gunTipPlacement == null)
        {
            return;
        }
        lastFired = Time.time;
        if (shootScript != null) { shootScript.Shoot(); clearPreviousPlaced(); }

    }
    Rigidbody rb;
    bool hasRB;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hasRB = TryGetComponent(out rb);
        if (attachedEvent == null)
            attachedEvent = new UnityEvent();
    }
    public Vector3 ScaleBy;

    public PlaceObject placeObject;

    public GunTipPlacement gunTipPlacement;
    public void clearPreviousPlaced()
    {
        if (placeObject != null)
        {
            placeObject.goOnTip = null;
        }
        if (gunTipPlacement != null)
        {
            gunTipPlacement.goOnTip = null;
        }
        placeObject = null;
        gunTipPlacement = null;
    }
    AudioSource audioSource;
    public void place()
    {
        if (hasRB) { rb.isKinematic = true; }
        transform.localScale = ScaleBy;
        attachedEvent.Invoke();
        if (TryGetComponent<AudioSource>(out audioSource))
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public bool NeedsToBeSaved()
    {
        return true;
    }

    public bool NeedsReinstantiation()
    {
        return true;
    }

    [System.Serializable]
    struct BlockData
    {
        public bool kinematicRB;
        public bool attachedToPlayer;

    }

    public object SaveState()
    {
        return new BlockData()
        {
            attachedToPlayer = !(gunTipPlacement == null)
        };
    }
    public void LoadState(object state)
    {
        BlockData data = (BlockData)state;
        gameObject.TryGetComponent(out rb);
    }

    public void PostInstantiation(object state)
    {
        BlockData data = (BlockData)state;
        rb.isKinematic = false;
        if (transform.parent)
        {
            transform.parent.SetParent(null, true);
        }

        if (data.attachedToPlayer)
        {
            transform.position = player.transform.position; transform.parent.position = player.transform.position;
        }

    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
    }
}
