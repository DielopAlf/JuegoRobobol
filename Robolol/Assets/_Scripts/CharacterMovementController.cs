using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public TMP_Text livesText; 

    public int lives = 3;
    public float hitTimer = 1;

    public float knockback = 10;
    [SerializeField]
    float initialAngle;

    bool inmunity = false;
    public bool inputLock = false;

    //Audio:
    [SerializeField]
    AudioSource audioSource, audioSourceWalk;

    [SerializeField]
    AudioClip walk;

   [SerializeField]
    AudioClip    damageSound;

   
    [SerializeField]
    AudioClip deathSound;



    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
                UpdateLivesText();

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
    private void Update()
    {
        // Reproduce el sonido de caminar solo cuando el personaje comienza a moverse
        if (IsMoving == false)
        {
            audioSourceWalk.Play();
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
        PlayDeathSound();

        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(2);
        gameObject.SetActive (false);
    }
   IEnumerator Hit()
    {
        inmunity = true;
        lives--;
        PlayDamageSound();

         UpdateLivesText(); 
        yield return new WaitForSeconds(hitTimer);
        inmunity = false;
    }
    private void UpdateLivesText()
    {
        livesText.text = "Vidas = " + lives.ToString();
    }
     private void PlayDamageSound()
    {
        if (audioSource != null && damageSound != null)
        {
            audioSource.clip = damageSound;
            audioSource.Play();
        }
     }
      private void PlayDeathSound()
    {
        if (audioSource != null && deathSound != null)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
        }
    }
}
