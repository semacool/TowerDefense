using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSale : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
        var infoState = transform.parent.GetComponent<InfoClick>();
        var tower = infoState.SelectedTower;
        if (tower == null) return;
        if (tower.GetComponent<ShopItem>().Byed) return;
        StateLevel.Get.Money += tower.Sale;
        Destroy(tower.gameObject);
        infoState.ShowInfo(tower);
    }
}
