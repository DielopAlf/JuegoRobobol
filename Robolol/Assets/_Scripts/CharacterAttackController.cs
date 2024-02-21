using System.Collections;
using System.Collections.Generic;
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
            }
            if (attackDuration <= 0)
            {
                CharacterMovementController.instance.attacking = false;
                attacking = false;
                attackDuration = attackDurationTime;
                cooldown = true;
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
                StartCoroutine(enemyHit());
            }
        }
        IEnumerator enemyHit()
        {
            enemyDead = true;
            Instantiate(blood, other.transform.position, Quaternion.identity);
            Destroy(other.GetComponent<CharacterMovementController>());
            yield return new WaitForSeconds(1.5f);
            Destroy(GameObject.FindGameObjectWithTag("Blood"));
            other.GetComponent<Animator>().SetBool("IsDead", enemyDead);
            EnemyDetectionAreaController.instance.enemyList.Remove(other.gameObject);
            Destroy(other.gameObject);

        }
    }
}

