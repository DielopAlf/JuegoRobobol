using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 720f;
    CharacterController characterController;
    [SerializeField]
    Animator animator;
    bool IsMoving = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);
        movement.Normalize();

        characterController.Move(movement*speed*Time.deltaTime);

        if (EnemyDetectionAreaController.instance.enemyInRange == true)
        {
            gameObject.transform.LookAt(EnemyDetectionAreaController.instance.enemyTransform, Vector3.up);
        }
        else
        {
            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

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
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Player has been hit");

        if (hit.collider.tag == "Enemy")
        {
            Debug.Log("Player has been hit by an enemy");
            //gameObject.SetActive(false);
        }
    }
}
