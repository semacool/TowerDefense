using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickUpgrade : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
        var infoState = transform.parent.GetComponent<InfoClick>();
        var tower = infoState.SelectedTower;
        if (tower == null) return;

        if (tower.GetComponent<ShopItem>().Byed) return;
        if (StateLevel.Get.Money >= tower.UpgradeCost)
        {
            StateLevel.Get.Money -= tower.UpgradeCost;
            tower.Upgrade();
            infoState.ShowInfo(tower);
        }
    }
}
