using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


/// <summary>
/// Клик по кнопке, перезапуть уровень
/// </summary>
public class ClickRestart : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] int Scene;
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(Scene);
    }

}
