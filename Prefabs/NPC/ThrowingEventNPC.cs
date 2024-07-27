using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingEventNPC : MonoBehaviour
{
    Animator animator;
    ThrowingEventController throwingEventController;
    GameObject throwObject;
    public GameObject throwObjectPrefab;
    public GameObject handBone;
    RippleHandler rippleHandler;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        throwingEventController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ThrowingEventController>();
        throwingEventController.AddToThrowers(this);
        throwObject = Instantiate(throwObjectPrefab);
        throwObject.SetActive(false);
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
    }
    public void EndThrowing()
    {
        CancelInvoke();
    }

    void throwAction()
    {
        if (!rippleHandler.inDialogue)
        {
            animator.SetTrigger("ThrowingThings");
        }

    }
    public void StartThrowing()
    {
        InvokeRepeating("throwAction", Random.Range(0f, 10f), Random.Range(10f, 20f));



    }
    public void GetItemOnHand()
    {
        throwObject.SetActive(true);
        throwObject.GetComponentInChildren<Fracture>().enabled = false;
        throwObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
        throwObject.transform.position = handBone.transform.position;
        throwObject.transform.SetParent(handBone.transform, true);

    }
    public GameObject throwTarget;
    public float throwForce = 50f;
    public void ThrowItem()
    {
        throwObject.GetComponentInChildren<Fracture>().enabled = true;
        throwObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
        throwObject.transform.SetParent(null, true);
        throwObject.transform.LookAt(throwTarget.transform);
        throwObject.GetComponentInChildren<Rigidbody>().AddForce(throwObject.transform.forward * throwForce, ForceMode.Impulse);

    }
}
