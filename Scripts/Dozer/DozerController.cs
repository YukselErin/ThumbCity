using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozerController : MonoBehaviour
{
    bool chasePlayer = false;
    bool stopToRadio = false;
    bool patrol = true;
    DozerFollowPlayer dozerFollowPlayer;
    DozerShooter dozerShooter1;
    bool[] states;
    void Start()
    {
        GetComponentInChildren<DozerFollowPlayer>();
        bool[] statest = { chasePlayer, stopToRadio, patrol };
        states = statest;
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerPresentDuringPatrolChase();
    }
    void ifPlayerPresentDuringPatrolChase()
    {
        SetState(1);
        
    }
    void SetState(int i)
    {
        for (int index = 0; index < states.Length; index++)
        {
            states[index] = false;
        }
        states[i] = true;
    }
}
