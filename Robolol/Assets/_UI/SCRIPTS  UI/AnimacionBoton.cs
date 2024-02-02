using UnityEngine;
using UnityEngine.EventSystems;

public class AnimacionBoton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 tamanoNormal;
    private Vector3 tamanoAumentado = new Vector3(1.2f, 1.2f, 1.2f);
    public float duracionAnimacion = 0.3f;

    void Start()
    {
        tamanoNormal = transform.localScale;
    }

    // Implementaci�n de la interfaz IPointerEnterHandler
    public void OnPointerEnter(PointerEventData eventData)
    {
        EscalarGradualmente(tamanoAumentado);
    }

    // Implementaci�n de la interfaz IPointerExitHandler
    public void OnPointerExit(PointerEventData eventData)
    {
        EscalarGradualmente(tamanoNormal);
    }

    // Evento del rat�n
    void OnMouseEnter()
    {
        EscalarGradualmente(tamanoAumentado);
    }

    // Evento del rat�n
    void OnMouseExit()
    {
        EscalarGradualmente(tamanoNormal);
    }

    // Funci�n para escalar gradualmente el objeto
    private void EscalarGradualmente(Vector3 objetivo)
    {
        LeanTween.scale(gameObject, objetivo, duracionAnimacion);
    }
}
