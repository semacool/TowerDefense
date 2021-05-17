using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropOnPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            var pos = GetComponent<RectTransform>().anchoredPosition * 80;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}
