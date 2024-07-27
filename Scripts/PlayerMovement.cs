using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    InputAction move;
    void Awake()
    {
        playerControls = new PlayerControls();

    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }
    void OnDisable()
    {
        move.Disable();
    }
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = move.ReadValue<Vector2>();
        Vector3 temp = new Vector3();
        temp.x = vec.x*Time.deltaTime*20f;
        temp.z = vec.y*Time.deltaTime*20f;
        cc.Move(temp);
    }
}
