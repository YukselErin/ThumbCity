using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonController : MonoBehaviour
{
    public GameObject parent;
    public Transform dozerPosTransform;
    public GameObject dozer;
    DozerShooter dozerShooter;
    void Start()
    {
        playerDozerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDozerTarget>();
        dozerPos = dozerPosTransform.position;
        dozerShooter = dozer.GetComponentInChildren<DozerShooter>();
    }
    public void shoot()
    {
        Invoke("GoonAttack",attackDuration);
        attackTime = Time.time;
        goonParent.SetActive(true);
        playerDozerTarget.standOnPoint = true;
        playerDozerTarget.standPos = dozerPos;
        dozerShooter.lookAt = goonParent.transform;
        dozerShooter.shootElsewhere = true;
    }
    public Vector3 dozerPos;
    float attackTime = 0f;
    public float attackDuration = 0f;
    public GameObject goonParent;
    PlayerDozerTarget playerDozerTarget;
    void GoonAttack()
    {
       
        playerDozerTarget.standOnPoint = false;
        goonParent.SetActive(false);
        dozerShooter.shootElsewhere = false;
    }


}
