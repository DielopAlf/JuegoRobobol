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
    AudioClip victorySound;

    private bool gameOver = false;

    [SerializeField]
    AudioClip defeatSound;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameOver(defeatScreen, defeatSound, "Game Over - Player Died");
        }

        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            GameOver(victoryScreen, victorySound, "Victory - All enemies defeated");
        }
    }

    void GameOver(GameObject endScreen, AudioClip sound, string debugMessage)
    {
        if (!gameOver)
        {
            gameOver = true;

            audioSource.Stop();
            audioSource.PlayOneShot(sound);
            Time.timeScale = 0;
            endScreen.SetActive(true);
            Debug.Log(debugMessage);
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
