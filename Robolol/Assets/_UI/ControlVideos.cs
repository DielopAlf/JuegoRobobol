using UnityEngine;
using UnityEngine.Video;

public class ControlVideos : MonoBehaviour
{
    public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;

    private bool reproducirSiguiente = false;

    void Start()
    {
        
        videoPlayer1.loopPointReached += ReproducirSiguienteVideo;
    }

    void Update()
    {
        
        if (reproducirSiguiente)
        {
            
            videoPlayer2.Play();
            reproducirSiguiente = false;
        }
    }

    void ReproducirSiguienteVideo(VideoPlayer vp)
    {
        
        reproducirSiguiente = true;

        
        videoPlayer1.Stop();
    }
}
