using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionAreaController : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    public int listNumber = 0;

    public Vector3 enemyTransform;
    public bool enemyInRange = false;
    public static EnemyDetectionAreaController instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyList.Add(other.gameObject);
            Debug.Log("There are " + enemyList.Count + " Enemy/ies");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy in range");
            enemyTransform = other.transform.position;
            enemyInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyList.Remove(other.gameObject);
            Debug.Log("There are " + enemyList.Count + " Enemy/ies");
        }
    }
    private void Update()
    {
        if (listNumber > (enemyList.Count - 1))
        {
            listNumber = 0;
        }
        Mathf.Clamp(listNumber, 0, (enemyList.Count -1));
        if (Input.GetButtonDown("Fire2"))
        {
            if (listNumber != (enemyList.Count - 1))
            {
                listNumber++;
            }
            else
            {
                listNumber = 0;
            }
        }
        if (enemyList.Count == 0)
        {
            enemyInRange = false;
        }
        if (enemyInRange == true)
        {
            enemyTransform = enemyList[listNumber].transform.position;
        }
    }
}
