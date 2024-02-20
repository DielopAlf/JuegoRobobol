using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    
    public float tiempoInactividad = 10f;
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (Input.anyKey)
        {
            tiempoTranscurrido = 0f; 
        }

        if (tiempoTranscurrido >= tiempoInactividad)
        {
            
            SceneManager.LoadScene("Cinematica");
        }
    }
}


