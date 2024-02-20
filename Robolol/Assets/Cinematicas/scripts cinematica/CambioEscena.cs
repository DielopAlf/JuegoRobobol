using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CambioEscena : MonoBehaviour
{
    public VideoPlayer videoPlayer; 

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoTerminado;
        }
        else
        {
            Debug.LogError("No se ha asignado el componente VideoPlayer.");
        }
    }

    void OnVideoTerminado(VideoPlayer vp)
    {
        
        CargarSiguienteEscena();
    }

    void CargarSiguienteEscena()
    {
        
        SceneManager.LoadScene("Intro Scene");
    }
}
