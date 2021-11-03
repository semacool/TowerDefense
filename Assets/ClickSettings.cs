using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


/// <summary>
/// Клик по кнопке, переход в меню настроек
/// </summary>
public class ClickSettings : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(2);
    }
}
