using UnityEngine;
using UnityEngine.EventSystems;

public class DropOnPlace : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// Место для башни в магазине?
    /// </summary>
    [SerializeField] bool isShopPlace = false;
    public void OnDrop(PointerEventData eventData)
    {
        
        if(eventData.pointerDrag != null)
        {
            var pos = GetComponent<RectTransform>().position;
            eventData.pointerDrag.GetComponent<RectTransform>().position = pos;
            if (!isShopPlace)
            {
                var shopItem = eventData.pointerDrag.GetComponent<ShopItem>();
                ShopState.Get.Bye(shopItem);
            }           
        }
    }
}
