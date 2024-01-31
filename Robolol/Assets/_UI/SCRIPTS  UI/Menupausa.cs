using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menupausa : MonoBehaviour

{
    [SerializeField]
    GameObject pauseContainer;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseContainer.activeInHierarchy == true)
            {
                pauseContainer.SetActive(false);
            }
            else
            {
                pauseContainer.SetActive(true);
            }
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void Resume()
    {
        if (pauseContainer.activeInHierarchy == true)
        {
            pauseContainer.SetActive(false);
        }
        else
        {
            pauseContainer.SetActive(true);
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainmenuScene");
    }
}
