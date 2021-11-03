using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Клик по кнопке, переход на 1 уровень
/// </summary>
public class ClickLevel : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] int IndexScene;
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(IndexScene);
    }
}
