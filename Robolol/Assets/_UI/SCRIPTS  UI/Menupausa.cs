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
        // Toggle activar/desactivar el menú de pausa
        pauseContainer.SetActive(!pauseContainer.activeInHierarchy);

        // Si el menú de opciones está abierto, ciérralo al abrir/cerrar el menú de pausa
        if (isOptionMenuOpen)
        {
            CloseOptionsMenu();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }

    public void Resume()
    {
        TogglePauseMenu();
    }

    public void OpenOptionsMenu()
    {
        // Cerrar el menú de pausa al abrir las opciones
       // TogglePauseMenu();
         CloseMainMenu();
        optionsMenu.SetActive(true);
       
        isOptionMenuOpen = true;
    }

    

    IEnumerator CloseOptionsMenuAfterAnimation()
    {
        yield return new WaitForSeconds(0.10f);

        // No cerrar el menú de pausa aquí

        // Volver a activar el menú de pausa después de cerrar las opciones
        Resume();  // Usar Resume() en lugar de TogglePauseMenu() para evitar un bucle
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;

        // Volver a activar el menú principal después de cerrar las opciones
        ShowMainMenu();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main menu");

        // Asegúrate de que el menú de pausa esté activo al salir del menú de opciones
        pauseContainer.SetActive(true);

        // Cerrar el menú de opciones
        CloseOptionsMenu();
    }
     private void CloseMainMenu()
    {
        // Desactivar o esconder elementos del menú principal según tus necesidades
        pauseContainer.SetActive(false);
    }

    // Nueva función para volver a mostrar el menú principal
    private void ShowMainMenu()
    {
        // Volver a activar elementos del menú principal según tus necesidades
        pauseContainer.SetActive(true);
    }
}

