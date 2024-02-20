using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public Button botonJuego;
    private bool botonVisible = false;

    void Start()
    {
        botonJuego.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            ActivarBoton();
        }

        
        if (botonVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            saltar_video();
        }
    }

    void ActivarBoton()
    {
        botonJuego.gameObject.SetActive(true);
        botonVisible = true;

        
        Invoke("DesactivarBoton", 3f);
    }

    void DesactivarBoton()
    {
        botonJuego.gameObject.SetActive(false);
        botonVisible = false;
    }

    public void saltar_video()
    {
        SceneManager.LoadScene("Intro Scene");
    }
}
