using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Shoot : MonoBehaviour
{
    private BulletSpawner bulletSpawner;
    PlayerControls playerControls;
    InputAction shoot;
    GunTipPlacement gunTipPlacement;
    RippleHandler dialogueHandler;


    void Awake()
    {
        playerControls = new PlayerControls();
        gunTipPlacement = GetComponentInChildren<GunTipPlacement>();
    }

    void OnEnable()
    {
        shoot = playerControls.Player.Shoot;
        shoot.Enable();
        shoot.performed += ShootAction;
    }
    void OnDisable()
    {
        shoot.Disable();

    }
    Animator animator;
    AudioSource audioSource;
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        animator = GetComponent<Animator>();
        bulletSpawner = GetComponent<BulletSpawner>();
        audioSource = GetComponent<AudioSource>();
    }
    public GameObject bulletPrefab;
    public Transform PlayerTransform;
    GameObject shootingBullet;
    public Transform bulletOrigin;
    public float bulletforce = 1f;
    void ShootAction(InputAction.CallbackContext context)
    {
        if (dialogueHandler.inDialogue)
        {
            return;
        }
        if (gunTipPlacement.attachmentOnTip)
        {
            gunTipPlacement.Shoot();
            gunTipPlacement.attachmentOnTip = false;
        }
        else
        {
            shootingBullet = bulletSpawner._pool.Get();
            shootingBullet.transform.position = bulletOrigin.position;
            shootingBullet.transform.rotation = quaternion.identity;
            shootingBullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            shootingBullet.GetComponent<Rigidbody>().AddForce(bulletOrigin.forward * bulletforce, ForceMode.Impulse);
            animator.SetTrigger("Shoot");
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
