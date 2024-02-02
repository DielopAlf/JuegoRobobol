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

    // Implementación de la interfaz IPointerEnterHandler
    public void OnPointerEnter(PointerEventData eventData)
    {
        EscalarGradualmente(tamanoAumentado);
    }

    // Implementación de la interfaz IPointerExitHandler
    public void OnPointerExit(PointerEventData eventData)
    {
        EscalarGradualmente(tamanoNormal);
    }

    // Evento del ratón
    void OnMouseEnter()
    {
        EscalarGradualmente(tamanoAumentado);
    }

    // Evento del ratón
    void OnMouseExit()
    {
        EscalarGradualmente(tamanoNormal);
    }

    // Función para escalar gradualmente el objeto
    private void EscalarGradualmente(Vector3 objetivo)
    {
        LeanTween.scale(gameObject, objetivo, duracionAnimacion);
    }
}
