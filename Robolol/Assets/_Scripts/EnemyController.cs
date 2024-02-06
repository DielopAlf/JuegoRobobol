using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform player;

    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
    }
}
