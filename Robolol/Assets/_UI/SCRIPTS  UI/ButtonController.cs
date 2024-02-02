using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject optionsMenu;
    public Animator optionsMenuAnimator;
    private bool isOptionMenuOpen = false;
    public Button playButton, optionsButton, exitButton;
    public GameObject creditsCanvas;

    void Start()
    {
        optionsMenu.SetActive(false);

        if (playButton == null || optionsButton == null || exitButton == null)
        {
            Debug.LogError("Button references not assigned in the inspector.");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void CloseGame()
    {
        Debug.Log("Se ha cerrado el juego");
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        optionsMenuAnimator.Play("Menu_Opening");
        isOptionMenuOpen = true;
    }

    public void CloseOptionsMenuAnimation()
    {
        optionsMenuAnimator.Play("Menu_Closing");
        optionsMenuAnimator.SetBool("Closed", true);
        StartCoroutine(CloseOptionsMenuAfterAnimation());
    }

    IEnumerator CloseOptionsMenuAfterAnimation()
    {
        yield return new WaitForSeconds(0.10f);
        CloseOptionsMenu();
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;
    }

    public void Credits()
    {
        creditsCanvas.SetActive(true);
    }

    public void BackMainMenu()
    {
        creditsCanvas.SetActive(false);
    }

    public void Update()
    {
        if (isOptionMenuOpen)
        {
            playButton.interactable = false;
            optionsButton.interactable = false;
            exitButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
            optionsButton.interactable = true;
            exitButton.interactable = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
