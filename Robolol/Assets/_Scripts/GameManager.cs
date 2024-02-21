using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.Log("Partida Terminada");
            Time.timeScale = 0f;
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Debug.Log("Hay Enemigos");
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            Debug.Log("Partida Terminada");
            Time.timeScale = 0f;
        }
    }
}
