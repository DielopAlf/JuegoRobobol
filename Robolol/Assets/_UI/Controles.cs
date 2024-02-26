using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    public AudioSource buttonAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1.0f;
    }
    public void StartGame()
    {
        StartCoroutine(PlayAndLoadScene("ESCENA DE PRUEBA", 0.3f));
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
    
    // Update is called once per frame
    IEnumerator PlayAndLoadScene(string sceneName, float delay)
    {
        PlayButtonSound();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
