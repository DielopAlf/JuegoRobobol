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

    private void Start()
    {
        attackDuration = attackDurationTime;
        attackCooldown = attackCooldownTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && attackCooldown == attackCooldownTime)
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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (attacking == true)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
