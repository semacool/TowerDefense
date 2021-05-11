using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTower : MonoBehaviour , IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] Canvas canvas;

    RectTransform rectTransform;
    CanvasGroup canvasGroupe;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroupe = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroupe.blocksRaycasts = true;
        canvasGroupe.alpha = 1f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroupe.blocksRaycasts = false;
        canvasGroupe.alpha = 0.5f;
    }
}
