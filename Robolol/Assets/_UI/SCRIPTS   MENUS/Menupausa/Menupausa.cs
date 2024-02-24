using System.Collections;
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

    public AudioSource buttonAudioSource;
    public AudioSource musicAudioSource; // Agrega esta línea para la música
    private int selectedButtonIndex = 0;

    void Start()
    {
        menuOpciones.SetActive(false);

        if (buttonAudioSource == null)
        {
            Debug.LogError("Button Audio Source not assigned in the inspector.");
        }

        if (musicAudioSource == null)
        {
            Debug.LogError("Music Audio Source not assigned in the inspector.");
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
        PauseMusic();
    }

    public void ReanudarJuego()
    {
        StartCoroutine(WaitSeconds(0.3f));
        ResumeMusic();
    }

    private void PauseMusic()
    {
        if (musicAudioSource != null && musicAudioSource.isPlaying)
        {
            musicAudioSource.Pause();
        }
    }

    private void ResumeMusic()
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.UnPause();
        }
    }

    public IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("Esperar Fin" + Time.time);

        Time.timeScale = 1;
        juegoPausado = false;
        menuPausa.SetActive(false);
    }

    public void AbrirMenuOpciones()
    {
        StartCoroutine(WaitSeconds1(0.3f));
    }

    public IEnumerator WaitSeconds1(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("Esperar Fin" + Time.time);

        enMenuOpciones = true;
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void VolverAMenuPausa()
    {
        StartCoroutine(WaitSeconds2(0.3f));
    }

    public IEnumerator WaitSeconds2(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("Esperar Fin" + Time.time);

        enMenuOpciones = false;
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
    }

    public void ReiniciarJuego()
    {
        Debug.Log("Esperar Inicial" + Time.time);
        StartCoroutine(WaitSeconds3(0.3f));
    }

    public IEnumerator WaitSeconds3(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("Esperar Fin" + Time.time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
    }

    public void SalirAlMenuPrincipal()
    {
        Debug.Log("Saliendo al menú principal...");
        StartCoroutine(WaitSeconds4(0.3f));
    }

    public IEnumerator WaitSeconds4(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("Esperar Fin" + Time.time);

        if (juegoPausado || enMenuOpciones)
        {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene("Main menu");
    }

    public void BotonReanudar()
    {
        ReanudarJuego();
    }

    public void BotonReiniciar()
    {
        ReiniciarJuego();
    }
}
