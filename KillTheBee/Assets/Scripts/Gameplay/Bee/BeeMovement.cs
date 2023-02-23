using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    private void Update()
    {
        agent.SetDestination(GameManager.Instance.playerInstance.transform.position);
    }
}
