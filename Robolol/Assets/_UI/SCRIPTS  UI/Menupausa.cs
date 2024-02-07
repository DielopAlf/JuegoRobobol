using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menupausa : MonoBehaviour, IPointerEnterHandler
{
    public GameObject optionsMenu;
    private bool isOptionMenuOpen = false;
    [SerializeField] private GameObject menuPausa;
    public GameObject creditsCanvas;
    [SerializeField] GameObject pauseContainer;
    private bool juegopausado = false;
    public AudioSource audioSource;

    private Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (juegopausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ExpandirBoton(0.2f);
    }

    private void ExpandirBoton(float expansionAmount)
    {
        menuButton.transform.localScale += new Vector3(expansionAmount, expansionAmount, 0f);
    }

    public void Pausa()
    {
        juegopausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActivarMenuOpciones()
    {
        if (!juegopausado)
        {
            Pausa();
        }

        menuPausa.SetActive(false);
        OpenOptionsMenu();
    }

    public void CambiarAEscena(string nombreDeEscena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreDeEscena);
    }

    public void OpenOptionsMenu()
    {
        StartCoroutine(PlayAndOpenOptionsMenu());
    }

    IEnumerator PlayAndOpenOptionsMenu()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }

        CloseMainMenu();
        optionsMenu.SetActive(true);
        isOptionMenuOpen = true;
    }

    public void CloseOptionsMenu()
    {
        StartCoroutine(PlayAndCloseOptionsMenu());
    }

    IEnumerator PlayAndCloseOptionsMenu()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }

        optionsMenu.SetActive(false);
        isOptionMenuOpen = false;
        ShowMainMenu();
    }

    private void CloseMainMenu()
    {
        pauseContainer.SetActive(false);
    }

    private void ShowMainMenu()
    {
        pauseContainer.SetActive(true);
    }
}
