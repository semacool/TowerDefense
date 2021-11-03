using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Нажатие на кнопку, показ окна магазина
/// </summary>
public class ClickShopButton : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// Магазин
    /// </summary>
    [SerializeField] public GameObject Shop;

    public void OnPointerDown(PointerEventData eventData)
    {
        Shop.SetActive(!Shop.activeSelf);
    }
}
