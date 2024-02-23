using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CharacterAttackController : MonoBehaviour
{
    public static CharacterAttackController instance;
    private float attackDuration;
    public float attackDurationTime;
    private float attackCooldown;
    public float attackCooldownTime;
    private bool attacking = false;
    private bool cooldown = false;
    private bool hasHitEnemy = false; // Nueva variable para rastrear si ya se ha golpeado al enemigo
    [SerializeField]
    Animator animator;
    public bool enemyDead = false;

    [SerializeField]
    GameObject robot;
    public float valor = 2;

    [SerializeField]
    GameObject blood;

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip punch;
    [SerializeField]
    AudioClip hitEnemy; // AudioClip para el sonido de golpear al enemigo

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        attackDuration = attackDurationTime;
        attackCooldown = attackCooldownTime;
    }

    private void Update()
    {
        if (CharacterMovementController.instance.inputLock != true)
        {
            if (Input.GetButtonDown("Fire1") && attackCooldown == attackCooldownTime)
            {
                audioSource.clip = punch;
                audioSource.Play();
                attacking = true;
                CharacterMovementController.instance.attacking = true;
            }
            if (attacking == true)
            {
                attackDuration -= Time.deltaTime;

                // Si aún no ha golpeado al enemigo y el tiempo de duración es mayor que el tiempo deseado para golpear
                if (!hasHitEnemy && attackDurationTime - attackDuration >= 0.1f)
                {
                    StartCoroutine(HitEnemySound());
                }
            }
            if (attackDuration <= 0)
            {
                CharacterMovementController.instance.attacking = false;
                attacking = false;
                attackDuration = attackDurationTime;
                cooldown = true;
                hasHitEnemy = false; // Restablece la variable al final del ataque
            }
            if (cooldown == true)
            {
                attackCooldown -= Time.deltaTime;
            }
            if (attackCooldown <= 0)
            {
                cooldown = false;
                attackCooldown = attackCooldownTime;
            }

            animator.SetBool("Attacking", attacking);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (attacking == true)
            {
                StartCoroutine(enemyHit(other.gameObject));
            }
        }
    }

    IEnumerator HitEnemySound()
    {
        // Reproduce el sonido al golpear al enemigo
        if (audioSource != null && hitEnemy != null)
        {
            audioSource.clip = hitEnemy;
            audioSource.Play();
        }

        hasHitEnemy = true; // Marca que ya se ha golpeado al enemigo

        yield return null;
    }

    IEnumerator enemyHit(GameObject enemy)
    {
        enemyDead = true;
        Instantiate(blood, enemy.transform.position, Quaternion.identity);
        Destroy(enemy.GetComponent<CharacterMovementController>());
        yield return new WaitForSeconds(1.5f);
        Destroy(GameObject.FindGameObjectWithTag("Blood"));
        enemy.GetComponent<Animator>().SetBool("IsDead", enemyDead);

        EnemyDetectionAreaController.instance.enemyList.Remove(enemy);
        Destroy(enemy);
    }
}
