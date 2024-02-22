using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject defeatScreen;
    public GameObject victoryScreen;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip Victoria;

    private bool gameOver = false;

    [SerializeField]
    AudioClip Derrota;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOver = true;

            audioSource.Stop(); // Detiene cualquier sonido que esté reproduciéndose
            audioSource.clip = Derrota;
            audioSource.Play();
            Time.timeScale = 0;
            defeatScreen.SetActive(true);
            Debug.Log("Game Over - Player Died");
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Debug.Log("Hay Enemigos");
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            gameOver = true;
            audioSource.Stop(); // Detiene cualquier sonido que esté reproduciéndose
            audioSource.clip = Victoria;
            audioSource.Play();
            Time.timeScale = 0;
            victoryScreen.SetActive(true);
            Debug.Log("Victory - All enemies defeated");
        }
    }
    public void RestartGame()
    {
        gameOver = false;

        Time.timeScale = 1;
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(false);

        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void LoadMainMenu()
    {
        gameOver = false;

        Time.timeScale = 1;
        SceneManager.LoadScene("Main menu");
    }
}
