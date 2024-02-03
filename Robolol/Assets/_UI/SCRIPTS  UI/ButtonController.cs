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
    public GameObject menuPrincipal;
    
    public AudioSource backgroundMusic;  // AudioSource para la música de fondo
    public AudioClip buttonClickClip;    // AudioClip para el sonido al pulsar el botón

    void Start()
    {
        optionsMenu.SetActive(false);

        if (playButton == null || optionsButton == null || exitButton == null)
        {
            Debug.LogError("Button references not assigned in the inspector.");
        }

        PlayBackgroundMusic();  // Reproduce la música de fondo al iniciar
    }

    void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void StartGame()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void CloseGame()
    {
        PlayButtonClickSound();
        Debug.Log("Se ha cerrado el juego");
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        CloseMainMenu();

        optionsMenu.SetActive(true);
        optionsMenuAnimator.Play("Menu_Opening");
        isOptionMenuOpen = true;
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;

        ActivateMainMenu();
        PlayButtonClickSound(); // Mueve PlayButtonClickSound() aquí
    }

    public void Credits()
    {
        CloseMainMenu();

        creditsCanvas.SetActive(true);
        PlayButtonClickSound(); // Agrega esto
    }

    public void BackMainMenu()
    {
        creditsCanvas.SetActive(false);
        ActivateMainMenu();
        PlayButtonClickSound(); // Agrega esto
    }

    public void Update()
    {
        playButton.interactable = !isOptionMenuOpen;
        optionsButton.interactable = !isOptionMenuOpen;
        exitButton.interactable = !isOptionMenuOpen;
    }

    public void QuitGame()
    {
        PlayButtonClickSound();
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

    private void PlayButtonClickSound()
    {
        if (buttonClickClip != null)
        {
            AudioSource.PlayClipAtPoint(buttonClickClip, Camera.main.transform.position);
        }
    }
}
