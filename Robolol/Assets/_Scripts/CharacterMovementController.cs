using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public static CharacterMovementController instance;
    public float speed = 10f;
    public float rotationSpeed = 720f;
    CharacterController characterController;
    [SerializeField]
    Animator animator;
    bool IsMoving = false;
    public bool attacking = false;

    public int lives = 3;
    public float hitTimer = 1;

    public float knockback = 10;
    [SerializeField]
    float initialAngle;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        if (attacking != true)
        {
            Debug.Log(lives);

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(x, 0, y);
            movement.Normalize();

            characterController.Move(movement * speed * Time.deltaTime);

            if (EnemyDetectionAreaController.instance.enemyInRange == true)
            {
                gameObject.transform.LookAt(new Vector3(EnemyDetectionAreaController.instance.enemyTransform.x, gameObject.transform.position.y, EnemyDetectionAreaController.instance.enemyTransform.z));
            }
            else
            {
                if (movement != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movement);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }
            }
            if (movement != Vector3.zero)
            {
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }

            animator.SetBool("IsMoving", IsMoving);

            if (hitTimer <= 0)
            {
                hitTimer = 1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has been hit");

        if (other.tag == "Enemy" && lives != 0)
        {
            StartCoroutine(Hit());
            var rigid = other.GetComponent<Rigidbody>();

            Vector3 p = other.transform.position;

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

            rigid.velocity = -finalVelocity;

            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * knockback, ForceMode.Impulse);
            Debug.Log("Player has been hit by an enemy");
        }
        if (other.tag == "Enemy" && lives == 0)
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Hit()
    {
        lives--;
        yield return new WaitForSeconds(hitTimer);
    }
}
