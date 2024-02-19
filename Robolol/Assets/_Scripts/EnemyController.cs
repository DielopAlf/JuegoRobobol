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
    Vector3 enemyLastPosition;
    public float time;
    Animator animator;
    NavMeshAgent agent;
    AnimationCurve heightCurve;

    bool OnTheFloor = true;
    bool Movement = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        if (Vector3.Distance(gameObject.transform.position, player.position) <= distanceJump)
        {
            Jump();
        }
        else
        {
            agent.destination = player.position;
        }

        if (agent.velocity != Vector3.zero)
        {
            Movement = true;
        }
        else
        {
            Movement = false;
        }
        if (agent.velocity.y > 0)
        {
            OnTheFloor = false;
        }
        else
        {
            OnTheFloor = true;
        }

        animator.SetBool("IsMoving", Movement);
        animator.SetBool("OnTheFloor", OnTheFloor);
    }
    void Jump()
    {
        agent.isStopped = true;
        playerLastPosition = player.position;
        gameObject.transform.Translate (new Vector3(playerLastPosition.x, Mathf.Sin(playerLastPosition.y), playerLastPosition.z) * Time.deltaTime);
        Debug.Log("Has jumped");
    }
}
