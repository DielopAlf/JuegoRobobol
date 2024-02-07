using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float distanceJump;
    Vector3 playerLastPosition;

    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (Vector3.Distance(gameObject.transform.position, player.position) <= distanceJump)
        {
            Jump();
        }
        else
        {
            agent.destination = player.position;
        }
    }
    void Jump()
    {
        playerLastPosition = player.position;
        //gameObject.transform.Translate(new Vector3 (playerLastPosition.x, Mathf.Sin(playerLastPosition.y), playerLastPosition.z) * Time.deltaTime);
        Debug.Log("Has jumped");
    }
}
