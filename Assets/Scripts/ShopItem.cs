using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Объект в магазине
/// </summary>
public class ShopItem : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// Цена
    /// </summary>
    public float Cost;

    /// <summary>
    /// Объект куплен?
    /// </summary>
    public bool Byed;

    private void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var info = gameObject.GetComponent<TowerBase>();
        var stateInfo = GameObject.FindGameObjectsWithTag("Info");
        foreach (var item in stateInfo)
        {
            item.GetComponent<InfoClick>().ShowInfo(info);
        }
        
    }
}
