using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour
{
    public GameObject optionsMenu;
    private bool isOptionMenuOpen = false;
    public Button playButton, optionsButton, exitButton;
    public GameObject creditsCanvas;
    [SerializeField] GameObject pauseContainer;

    public AudioSource audioSource;

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
        StartCoroutine(PlayAndTogglePauseMenu());
    }

    IEnumerator PlayAndTogglePauseMenu()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f); // Ajusta el tiempo de espera según tus necesidades
        }

        pauseContainer.SetActive(!pauseContainer.activeInHierarchy);

        if (isOptionMenuOpen)
        {
            CloseOptionsMenu();
        }
    }

    public void ResetGame()
    {
        StartCoroutine(PlayAndResetGame());
    }

    IEnumerator PlayAndResetGame()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f); // Ajusta el tiempo de espera según tus necesidades
        }

        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void Resume()
    {
        TogglePauseMenu();
    }

    public void OpenOptionsMenu()
    {
        StartCoroutine(PlayAndOpenOptionsMenu());
    }

    IEnumerator PlayAndOpenOptionsMenu()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f); // Ajusta el tiempo de espera según tus necesidades
        }

        CloseMainMenu();
        optionsMenu.SetActive(true);
        isOptionMenuOpen = true;
    }

    IEnumerator CloseOptionsMenuAfterAnimation()
    {
        yield return new WaitForSeconds(0.10f);
        Resume();
    }

    public void CloseOptionsMenu()
    {
        StartCoroutine(PlayAndCloseOptionsMenu());
    }

    IEnumerator PlayAndCloseOptionsMenu()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f); // Ajusta el tiempo de espera según tus necesidades
        }

        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;
        ShowMainMenu();
    }

    public void ReturnToMainMenu()
    {
        StartCoroutine(PlayAndReturnToMainMenu());
    }

    IEnumerator PlayAndReturnToMainMenu()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f); // Ajusta el tiempo de espera según tus necesidades
        }

        SceneManager.LoadScene("Main menu");
        pauseContainer.SetActive(true);
        CloseOptionsMenu();
    }

    private void CloseMainMenu()
    {
        pauseContainer.SetActive(false);
    }

    private void ShowMainMenu()
    {
        pauseContainer.SetActive(true);
    }
}
