using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CambioEscena : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Asigna tu componente VideoPlayer en el Inspector

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
        // Este método se llama cuando el video llega al final
        CargarSiguienteEscena();
    }

    void CargarSiguienteEscena()
    {
        // Aquí defines el índice o el nombre de la siguiente escena que quieres cargar
        // Puedes usar SceneManager.LoadScene("NombreDeLaSiguienteEscena") o SceneManager.LoadScene(1) por ejemplo
        // Asegúrate de que la escena esté incluida en la compilación en Build Settings.
        SceneManager.LoadScene("ESCENA DE PRUEBA");
    }
}
