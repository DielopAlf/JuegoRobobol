using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour
{
    [SerializeField]
    GameObject pauseContainer;

 private void Update()
{
    if (Input.GetKeyUp(KeyCode.Escape))
    {
        Debug.Log("Escape key pressed");
        TogglePauseMenu();
    }
}


    private void TogglePauseMenu()
    {
        pauseContainer.SetActive(!pauseContainer.activeInHierarchy);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void Resume()
    {
        TogglePauseMenu();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
