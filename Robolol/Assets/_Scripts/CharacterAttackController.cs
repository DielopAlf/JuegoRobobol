using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    private float attackDuration;
    public float attackDurationTime;
    private float attackCooldown;
    public float attackCooldownTime;
    private bool attacking = false;
    private bool cooldown = false;
    [SerializeField]
    Animator animator;

    private void Start()
    {
        attackDuration = attackDurationTime;
        attackCooldown = attackCooldownTime;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && attackCooldown == attackCooldownTime)
        {
            attacking = true;
        }
        if (attacking == true)
        {
            attackDuration -= Time.deltaTime;
        }
        if (attackDuration <= 0)
        {
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
                EnemyDetectionAreaController.instance.enemyList.Remove(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }

}
