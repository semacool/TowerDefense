using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// Логика перетаскивания башен
/// </summary>
public class DragTower : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    /// <summary>
    /// Слой на котором проиходить передвижение
    /// </summary>
    [SerializeField] Canvas canvas;

    /// <summary>
    /// Магазин
    /// </summary>
    [SerializeField] GameObject Shop;

    /// <summary>
    /// Позиция и внешний вид башни
    /// </summary>
    RectTransform rectTransform;

    /// <summary>
    /// Дополнительная настройка внешнего вида
    /// </summary>
    CanvasGroup canvasGroupe;

    /// <summary>
    /// Радиус атаки
    /// </summary>
    Image rangeUI;
    /// <summary>
    /// Позиция до перетаскивания
    /// </summary>
    public Vector3 startPosition;

    /// <summary>
    /// Башня попало на место?
    /// </summary>
    public bool IsOnPlace = false;

    /// <summary>
    /// Действие, до старта объекта
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.position;
        canvasGroupe = GetComponent<CanvasGroup>();
        Shop = GameObject.Find("Shop");
        rangeUI = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();

        canvasGroupe.blocksRaycasts = true;
        canvasGroupe.alpha = 1f;
        rangeUI.enabled = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;         
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Shop.SetActive(true);
        transform.SetParent(Shop.transform);
        canvasGroupe.blocksRaycasts = true;
        canvasGroupe.alpha = 1f;
        rangeUI.enabled = false;
        if (IsOnPlace)
        {
            gameObject.GetComponent<TowerBase>().enabled = true;
            gameObject.transform.SetParent(canvas.transform);
            this.enabled = false;
        }
        else
        {
            rectTransform.position = startPosition;
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(Shop.transform.parent);
        Shop.SetActive(false);
        var range = gameObject.GetComponent<TowerBase>().Range;
        startPosition = rectTransform.position;
        canvasGroupe.blocksRaycasts = false;
        canvasGroupe.alpha = 0.5f;
        rangeUI.transform.localScale = new Vector3(range / 4, range / 4, 1);
        rangeUI.enabled = true;
    }
}
