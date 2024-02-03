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
    
    public AudioClip buttonClickClip;    // AudioClip para el sonido de los botones
    public AudioSource ambientSound;      // AudioSource para el sonido ambiente

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
        // Toggle activar/desactivar el men� de pausa
        pauseContainer.SetActive(!pauseContainer.activeInHierarchy);

        // Si el men� de opciones est� abierto, ci�rralo al abrir/cerrar el men� de pausa
        if (isOptionMenuOpen)
        {
            CloseOptionsMenu();
        }

        // Reproducir sonido ambiente al abrir/cerrar el men� de pausa
        PlayAmbientSound();
    }

    public void ResetGame()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void Resume()
    {
        PlayButtonClickSound();
        TogglePauseMenu();
    }

    public void OpenOptionsMenu()
    {
        PlayButtonClickSound();
        // Cerrar el men� de pausa al abrir las opciones
        // TogglePauseMenu();
        CloseMainMenu();
        optionsMenu.SetActive(true);

        isOptionMenuOpen = true;

        // Reproducir sonido ambiente al abrir el men� de opciones
        PlayAmbientSound();
    }

    IEnumerator CloseOptionsMenuAfterAnimation()
    {
        yield return new WaitForSeconds(0.10f);

        // No cerrar el men� de pausa aqu�

        // Volver a activar el men� de pausa despu�s de cerrar las opciones
        Resume();  // Usar Resume() en lugar de TogglePauseMenu() para evitar un bucle
    }

    public void CloseOptionsMenu()
    {
        PlayButtonClickSound();
        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;

        // Volver a activar el men� principal despu�s de cerrar las opciones
        ShowMainMenu();

        // Reproducir sonido ambiente al cerrar el men� de opciones
        PlayAmbientSound();
    }

    public void ReturnToMainMenu()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("Main menu");

        // Aseg�rate de que el men� de pausa est� activo al salir del men� de opciones
        pauseContainer.SetActive(true);

        // Cerrar el men� de opciones
        CloseOptionsMenu();
    }

    private void CloseMainMenu()
    {
        // Desactivar o esconder elementos del men� principal seg�n tus necesidades
        pauseContainer.SetActive(false);
    }

    // Nueva funci�n para volver a mostrar el men� principal
    private void ShowMainMenu()
    {
        // Volver a activar elementos del men� principal seg�n tus necesidades
        pauseContainer.SetActive(true);
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickClip != null)
        {
            AudioSource.PlayClipAtPoint(buttonClickClip, Camera.main.transform.position);
        }
    }

    private void PlayAmbientSound()
    {
        if (ambientSound != null && !ambientSound.isPlaying)
        {
            ambientSound.Play();
        }
    }
}
