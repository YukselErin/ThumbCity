using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;

public class DozerFollowPlayer : MonoBehaviour
{
    GameObject player;
    PlayerDozerTarget playerDozerTarget;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDozerTarget = player.GetComponent<PlayerDozerTarget>();
    }
    public GameObject[] patrolPoints;
    float lastPatrolChange = 0f;
    public bool standOnPoint = false;
    public Vector3 standingPosition;
    public GameObject startpoint;
    int everyOtherFrameRun = 5;
    int frame;
    // Update is called once per frame
    void Update()
    {
        if (!agent.enabled || frame % everyOtherFrameRun != 0)
        {
            frame++;

            return;
        }
        frame = 0;

        if (playerDozerTarget.startArea)
        {
            agent.SetDestination(startpoint.transform.position);
        }

        else if (playerDozerTarget.standOnPoint)
        {
            agent.SetDestination(playerDozerTarget.standPos);
        }

        else if (playerDozerTarget.followable)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (Time.time > lastPatrolChange + Random.Range(5f, 10f))
        {
            lastPatrolChange = Time.time;
            agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].transform.position);
        }
    }
}
