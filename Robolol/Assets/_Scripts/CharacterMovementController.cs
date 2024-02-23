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
    bool IsMovingBack = false;
    public bool attacking = false;
    private bool wasMoving = false;

    public int lives = 3;
    public float hitTimer = 1;

    public float knockback = 10;
    [SerializeField]
    float initialAngle;

    bool inmunity = false;
    public bool inputLock = false;

    //Audio:
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip walk;
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
    if (attacking != true && inputLock != true)
    {
        Debug.Log(lives);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);
        movement.Normalize();

        // Solo cambia la rotación si hay movimiento
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Controla el estado de movimiento para la animación
        IsMoving = movement != Vector3.zero;
        animator.SetBool("IsMoving", IsMoving);

        // Reproduce el sonido de caminar solo cuando el personaje comienza a moverse
        if (IsMoving && !wasMoving)
        {
            audioSource.clip = walk;
            audioSource.Play();
        }

        // Detiene el sonido si el personaje se detiene
        if (!IsMoving && wasMoving)
        {
            audioSource.Stop();
        }

        wasMoving = IsMoving;

        // Mueve al personaje
        characterController.Move(movement * speed * Time.deltaTime);

        if (EnemyDetectionAreaController.instance.enemyInRange == true)
        {
            gameObject.transform.LookAt(new Vector3(EnemyDetectionAreaController.instance.enemyTransform.x, gameObject.transform.position.y, EnemyDetectionAreaController.instance.enemyTransform.z));
        }

        if (hitTimer <= 0)
        {
            hitTimer = 1;
        }
    }


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has been hit");

        if (other.tag == "Enemy" && lives != 0 && inmunity ==false)
        {
            StartCoroutine(Hit());
            //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * knockback, ForceMode.Impulse);
            Debug.Log("Player has been hit by an enemy");
        }
        if (other.tag == "Enemy" && lives <= 0)
        {
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead()
    {
        inputLock = true;
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive (false);
    }
    IEnumerator Hit()
    {
        inmunity = true;
        lives--;
        yield return new WaitForSeconds(hitTimer);
        inmunity = false;
    }
}
