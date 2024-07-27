using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject goOnTip;
    GunPlaceableObject goOnTipScript;

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        GunPlaceableObject placeableObject;
        if (collider.gameObject.TryGetComponent<GunPlaceableObject>(out placeableObject))
        {
            if (placeableObject.Placeable())
            {
                placeableObject.clearPreviousPlaced();
                placeableObject.place();
                placeableObject.placeObject = this;
                goOnTip = collider.gameObject;
                goOnTipScript = placeableObject;
                Vector3 offset = placeableObject.attachmentPoint.position;

                collider.transform.parent.SetParent(transform, true);
                collider.transform.parent.localPosition = new Vector3(0f, 0f, 0f);
                collider.transform.localPosition = new Vector3(0f, 0f, 0f);


                offset = offset - transform.position;
                //collider.transform.Translate(offset);
                //collider.transform.Rotate(placeableObject.attachmentPoint.localRotation.eulerAngles);

                collider.transform.LookAt(transform.position + transform.forward * 0.1f);
                collider.transform.Rotate(placeableObject.attachmentPoint.localRotation.eulerAngles);
                collider.transform.position = collider.transform.position - placeableObject.attachmentPoint.localPosition;
            }
        }

    }
}
