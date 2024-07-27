using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Events;

public class GunTipPlacement : MonoBehaviour
{
    public UnityEvent newAttachmentOnGunEvent;
    public UnityEvent gunShotEvent;


    public bool attachmentOnTip = false;
    void Start()
    {
        if (newAttachmentOnGunEvent == null)
            newAttachmentOnGunEvent = new UnityEvent();
        if (gunShotEvent == null)
            gunShotEvent = new UnityEvent();
    }

    // Update is called once per frame
    public void Shoot()
    {
        gunShotEvent.Invoke();
        goOnTipScript.Shoot();
        attachmentOnTip = false;
    }
    public GameObject goOnTip;
    GunPlaceableObject goOnTipScript;
    void OnTriggerEnter(Collider collider)
    {
        GunPlaceableObject placeableObject;
        if (collider.gameObject.TryGetComponent<GunPlaceableObject>(out placeableObject) && !attachmentOnTip)
        {
            if (placeableObject.Placeable())
            {
                newAttachmentOnGunEvent.Invoke();
                placeableObject.clearPreviousPlaced();
                placeableObject.place();
                placeableObject.gunTipPlacement = this;
                goOnTip = collider.gameObject;
                goOnTipScript = placeableObject;
                attachmentOnTip = true;

                collider.transform.parent.SetParent(transform, true);
                collider.transform.parent.localPosition = new Vector3(0f, 0f, 0f);
                collider.transform.localPosition = new Vector3(0f, 0f, 0f);


                //collider.transform.Translate(offset);
                //collider.transform.Rotate(placeableObject.attachmentPoint.localRotation.eulerAngles);

                StartCoroutine(SetPos());
            }
        }

    }
    IEnumerator SetPos()
    {


        for (int i = 0; i < 3; i++)
        {
            if (goOnTip != null) goOnTip.transform.localPosition = new Vector3(0f, 0f, 0f);
            yield return null;
        }
        if (goOnTip == null)
        {
            StopAllCoroutines();
        }
        else
        {
            goOnTip.transform.parent.LookAt(transform.position + transform.forward * 0.1f);
            goOnTip.transform.LookAt(transform.position + transform.forward * 0.1f);
            goOnTip.transform.localPosition = goOnTip.transform.localPosition - goOnTipScript.attachmentPoint.localPosition;
        }

        // goOnTip.transform.rotation = quaternion.identity;
        //goOnTip.transform.Rotate(goOnTipScript.attachmentPoint.localRotation.eulerAngles);
    }
}
