using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMove : MonoBehaviour
{
    Vector3 startPoint;
    void OnTriggerEnter(Collider collider)
    {
        transform.position = startPoint;
    }
    CarMove carMove;
    void Start()
    {
        carMove = GameObject.FindGameObjectWithTag("GameController").GetComponent<CarMove>();
        startPoint = carMove.startPoint.position;
    }
    public float MoveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(1f, 0, 0f) * Time.deltaTime * MoveSpeed;

    }
}
