using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Клик по кнопке, поставить паузу
/// </summary>
public class ClickPause : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] GameObject pauseSolid;
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
        pauseSolid.SetActive(!pauseSolid.activeSelf);
        Time.timeScale = pauseSolid.activeSelf ? 0: 1;
    }
}
