using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float distanceJump;
    public float time;
    Animator animator;
    NavMeshAgent agent;

    //AnimationCurve heightCurve;
    bool OnTheFloor = true;
    bool Movement = false;

    //Jump:
    [SerializeField]
    float initialAngle;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        if (Vector3.Distance(gameObject.transform.position, player.position) <= distanceJump && OnTheFloor == true)
        {
            OnTheFloor = false;
            StartCoroutine(Jump());
            //Jump();
        }
        else if (agent.enabled == true)
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
        /*if (agent.velocity.y > 0)
        {
            OnTheFloor = false;
        }
        else
        {
            OnTheFloor = true;
        }*/

        animator.SetBool("IsMoving", Movement);
        animator.SetBool("OnTheFloor", OnTheFloor);
    }
    IEnumerator Jump()
    {
        Debug.Log("Has stopped");
        agent.enabled = false;
        var rigid = GetComponent<Rigidbody>();

        Vector3 p = player.position;

        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(p.x, 0, p.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

        float distance = Vector3.Distance(planarTarget, planarPostion);
        float yOffset = transform.position.y - p.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (p.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        rigid.velocity = finalVelocity;

        gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(rigid.velocity.x, 0, rigid.velocity.z));

        yield return new WaitForSeconds(time);
        OnTheFloor = true;
        agent.enabled = true;
        agent.destination = player.position;
    }
    /*void Jump()
    {
        Debug.Log("Has Jumped");
        playerLastPosition = player.position;
        agent.enabled = false;
        gameObject.transform.Translate (new Vector3 (playerLastPosition.x, Mathf.Sin(playerLastPosition.y), Mathf.Sin(playerLastPosition.z)) * Time.deltaTime);
    }*/
}
