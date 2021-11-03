using UnityEngine;

/// <summary>
/// Состояние магазина
/// </summary>
public class ShopState : MonoBehaviour
{
    /// <summary>
    /// Реализация singleton
    /// </summary>
    public static ShopState Get;

    private void Awake()
    {
        Get = this;
    }
    
    /// <summary>
    /// Покупка объекта
    /// </summary>
    /// <param name="item"></param>
    public void Bye(ShopItem item)
    {
        if(item.Cost <= StateLevel.Get.Money)
        {
           
            Instantiate(item.gameObject,item.gameObject.GetComponent<DragTower>().startPosition,Quaternion.identity,transform);
            item.gameObject.GetComponent<AudioSource>().Play();
            StateLevel.Get.Money -= item.Cost;
            item.gameObject.GetComponent<DragTower>().IsOnPlace = true;
            
        }
    }
}
