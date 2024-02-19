using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject optionsMenu;
    public bool isOptionMenuOpen = false;
    public Button playButton, optionsButton, exitButton;
    public GameObject creditsCanvas;
    public GameObject menuPrincipal;

    public AudioSource buttonAudioSource;
    private int selectedButtonIndex = 0;

    void Start()
    {
        optionsMenu.SetActive(false);

        if (buttonAudioSource == null)
        {
            Debug.LogError("Button Audio Source not assigned in the inspector.");
        }
    }

    public void PlayButtonSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
    }

    public void StartGame()
    {
        StartCoroutine(PlayAndLoadScene("ESCENA DE PRUEBA", 0.3f));
    }

    public void CloseGame()
    {
        StartCoroutine(PlayAndCloseGame());
    }

    IEnumerator PlayAndCloseGame()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Se ha cerrado el juego");
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        StartCoroutine(PlayAndOpenOptionsMenu());
    }

    IEnumerator PlayAndOpenOptionsMenu()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.3f);
        CloseMainMenu();
        optionsMenu.SetActive(true);
        isOptionMenuOpen = true;
    }

    public void CloseOptionsMenu()
    {
        StartCoroutine(PlayAndCloseOptionsMenu());
    }

    IEnumerator PlayAndCloseOptionsMenu()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.3f);
        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;
        ActivateMainMenu();
    }

    public void Credits()
    {
        StartCoroutine(PlayAndShowCredits());
    }

    IEnumerator PlayAndShowCredits()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.3f);
        CloseMainMenu();
        creditsCanvas.SetActive(true);
    }

    public void BackMainMenu()
    {
        StartCoroutine(PlayAndBackMainMenu());
    }

    IEnumerator PlayAndBackMainMenu()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.3f);
        creditsCanvas.SetActive(false);
        ActivateMainMenu();
    }

    public void QuitGame()
    {
        StartCoroutine(PlayAndQuitGame());
    }

    IEnumerator PlayAndQuitGame()
    {
        PlayButtonSound();
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }

    private void CloseMainMenu()
    {
        menuPrincipal.SetActive(false);
    }

    private void ActivateMainMenu()
    {
        menuPrincipal.SetActive(true);
    }

    IEnumerator PlayAndLoadScene(string sceneName, float delay)
    {
        PlayButtonSound();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
