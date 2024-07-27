using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveLoadSystem;

public class BasementExplosion : MonoBehaviour, ISaveable
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public PlaceObject placeObject;
    bool ColliderHit;
    bool explosiveOnCrack = false;
    Rocket rocket;
    float hititme = 0f;
    bool right = false;
    public Fracture fracture;
    void OnTriggerEnter(Collider collider)
    {
        if (exploded)
        {
            return;
        }
        if (placeObject.goOnTip != null)
        {
            right = placeObject.goOnTip.TryGetComponent<Rocket>(out rocket);
        }
        else { right = false; }


        if (collider.CompareTag("Bullet") && right)
        {
            ColliderHit = true;
            hititme = Time.time;
            Invoke("triggerExplosion", 1f);

        }

    }
    public GameObject insideroof;
    public GameObject pillar;
    public bool exploded = false;
    IEnumerator explosionTimer()
    {
        if (Time.time < hititme + 1f)
        {
            yield return null;
        }
        else
        {
            triggerExplosion();
        }

    }
    bool fractured;
    GameObject rootRef;
    public void triggerExplosion()
    {
        fracture.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        fracture.CauseFracture();
        rootRef = fracture.fragmentRoot;

        insideroof.SetActive(false);
        pillar.SetActive(false);

        exploded = true;
    }

    [System.Serializable]
    struct BlockData
    {
        public bool fractured;

    }

    public object SaveState()
    {
        return new BlockData()
        {
            fractured = fractured
        };
    }
    public void LoadState(object state)
    {
        BlockData data = (BlockData)state;
        fractured = data.fractured;
        Destroy(rootRef);
        fracture.gameObject.GetComponent<Rigidbody>().isKinematic = true;


        insideroof.SetActive(true);
        pillar.SetActive(true);

        exploded = false;
        fracture.gameObject.SetActive(true);
    }

    public bool NeedsToBeSaved()
    {
        return true;
    }
    public bool NeedsReinstantiation()
    {
        return false;
    }

    public void PostInstantiation(object state)
    {
        BlockData data = (BlockData)state;

    }
    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {

    }
}
