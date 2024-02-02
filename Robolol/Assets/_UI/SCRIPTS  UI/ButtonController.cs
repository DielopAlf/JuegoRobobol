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
        // Cerrar el menú principal al abrir las opciones
        CloseMainMenu();

        optionsMenu.SetActive(true);
        optionsMenuAnimator.Play("Menu_Opening");
        isOptionMenuOpen = true;
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;

        // Volver a activar el menú principal después de cerrar las opciones
        ActivateMainMenu();
    }

    public void Credits()
    {
        // Cerrar el menú principal al ver los créditos
        CloseMainMenu();

        creditsCanvas.SetActive(true);
    }

    public void BackMainMenu()
    {
        creditsCanvas.SetActive(false);

        // Volver a activar el menú principal después de cerrar los créditos
        ActivateMainMenu();
    }

    public void Update()
    {
        // Desactivar la interactividad de los botones cuando las opciones están abiertas
        playButton.interactable = !isOptionMenuOpen;
        optionsButton.interactable = !isOptionMenuOpen;
        exitButton.interactable = !isOptionMenuOpen;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CloseMainMenu()
    {
        // Desactivar o esconder elementos del menú principal según tus necesidades
        menuPrincipal.SetActive(false);
    }

    private void ActivateMainMenu()
    {
        // Volver a activar elementos del menú principal después de cerrar opciones o créditos
        menuPrincipal.SetActive(true);
    }
}
