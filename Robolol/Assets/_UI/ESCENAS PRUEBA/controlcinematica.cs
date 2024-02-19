using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class controlcinematica : MonoBehaviour
{
    public Button playButton;
    public AudioSource buttonAudioSource;
    public GameObject menuPrincipal;

    
    void Start()
    {
        
    }
     public void PlayButtonSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
    }

    public void StartJuego()
    {
        StartCoroutine(WaitSeconds(0.3f));

    }
    public IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
       

                SceneManager.LoadScene("Cinematica");

    }
}
