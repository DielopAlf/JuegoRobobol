using  System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour
{

    private bool juegoPausado = false;
    private bool enMenuOpciones = false;

    public GameObject menuPausa;
    public GameObject menuOpciones;

    // Agrega un AudioSource para reproducir el sonido

    public AudioSource buttonAudioSource;
    private int selectedButtonIndex = 0;
    void Start()
    {
        menuOpciones.SetActive(false);

        if (buttonAudioSource == null)
        {
            Debug.LogError("Button Audio Source not assigned in the inspector.");
        }
    }
    void Update()
    {
        if (!enMenuOpciones && Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }
    public void PlayButtonHoverSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.PlayOneShot(buttonAudioSource.clip);
        }
    }

    public void PlayButtonSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
        juegoPausado = true;
        menuPausa.SetActive(true);
        // Aquí puedes personalizar tu menú de pausa (mostrarlo en pantalla, etc.)
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1;
        juegoPausado = false;
        menuPausa.SetActive(false);


    }


    public void AbrirMenuOpciones()
    {
        enMenuOpciones = true;
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
        // Aquí puedes personalizar tu menú de opciones (mostrarlo en pantalla, etc.)
    }

    public void VolverAMenuPausa()
    {
        enMenuOpciones = false;
        menuOpciones.SetActive(false);
        menuPausa.SetActive(true);
        // Aquí puedes personalizar la transición de vuelta al menú de pausa
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Asegúrate de restablecer el tiempo a su escala normal después de reiniciar
        Time.timeScale = 1;
    }

    public void SalirAlMenuPrincipal()
    {
        Debug.Log("Saliendo al menú principal...");

        if (juegoPausado || enMenuOpciones)
        {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene("Main menu");
    }

    // Método que puedes asociar al botón de "Play" en tu interfaz de usuario
    public void BotonReanudar()
    {
        ReanudarJuego();
    }

    // Método que puedes asociar al botón de reinicio en tu interfaz de usuario
    public void BotonReiniciar()
    {
        ReiniciarJuego();
    }
}