using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Numerics;

public class PlayerHealth : MonoBehaviour
{
    CharacterController characterController;
    VolumeController volume;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<VolumeController>();
    }
    public float regenAmout = 10f;
    public float regenCD = 1f;
    bool regenActive = false;
    IEnumerator regenaration()
    {
        while (hitPoints < 100f)
        {
            if (lastHit + regenCD > Time.time)
            {
                yield return null;
            }
            else
            {
                hitPoints = hitPoints + Time.deltaTime * regenAmout;
            }
        }
        regenActive = false;
    }
    [SerializeField]
    float hitPoints = 100f;

    Bullet bullet;
    Blade blade;
    float lastHit = 0f;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.transform.parent.TryGetComponent<Bullet>(out bullet))
        {
            if (bullet.bounceAmount < 2f)
            {
                hitPoints = hitPoints - 30f;
                lastHit = Time.time;
                if (!regenActive)
                {
                    regenActive = true;
                    StartCoroutine(regenaration());
                }

            }
            else
            {
                characterController.SimpleMove(collision.transform.position.normalized);
            }
            checkHp();
        }

    }
    void checkHp()
    {
        if (hitPoints <= 0f)
        {
            volume.Blackout();
            gamoverCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void restoreHp()
    {
         gamoverCanvas.SetActive(false);
        hitPoints = 100f;
    }
    public GameObject gamoverCanvas;
    public void dealDamage(float dealDamage)
    {
        hitPoints -= dealDamage;
        checkHp();
    }

}
