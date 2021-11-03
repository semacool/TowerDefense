using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Клик по кнопке, переход на сцену главного меню
/// </summary>
public class ClickMenu : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
    }
}
