using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pantallasfinales : MonoBehaviour
{
    public static pantallasfinales instance;
    public int totalEnemies;
    private int enemiesDefeated = 0;
    public GameObject defeatScreen;
    public GameObject victoryScreen;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    enemiesDefeated = 0;
    }

    public void PlayerDied()
    {
        Time.timeScale = 0;
        defeatScreen.SetActive(true);
        Debug.Log("Game Over - Player Died");
    }

    public void RegisterEnemy()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= totalEnemies)
        {
            PlayerWins();
        }
    }
    public void PlayerWins()
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
        Debug.Log("Victory - All enemies defeated");
    }
   

    public void RestartGame()
    {
        Time.timeScale = 1;
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(false);
        
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main menu");
    }
}
