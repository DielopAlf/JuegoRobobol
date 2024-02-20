using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CharacterAttackController1 : MonoBehaviour
{
    public static CharacterAttackController1 instance;
    private float attackDuration;
    public float attackDurationTime;
    private float attackCooldown;
    public float attackCooldownTime;
    private bool attacking = false;
    private bool cooldown = false;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Animator monster;
    public bool enemyDead = false;

    [SerializeField]
    GameObject robot;
    public float valor = 2;

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
        if (Input.GetButtonDown("Fire1") && attackCooldown == attackCooldownTime)
        {
            robot.transform.Translate(Vector3.forward * valor * Time.deltaTime);
            attacking = true;
            CharacterMovementController1.instance.attacking = true;
        }
        if (attacking == true)
        {
            attackDuration -= Time.deltaTime;
        }
        if (attackDuration <= 0)
        {
            CharacterMovementController1.instance.attacking = false;
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
    yield return new WaitForSeconds(2);

    // Verificar si el objeto del enemigo y el componente Animator aún existen
    if (other != null && other.gameObject != null)
    {
        Animator enemyAnimator = other.gameObject.GetComponent<Animator>();

        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("IsDead", enemyDead);
        }

        other.gameObject.GetComponent<NavMeshAgent>().enabled = false;

        EnemyDetectionAreaController1.instance.enemyList.Remove(other.gameObject);
        Destroy(other.gameObject);
    }
  }
}
}

