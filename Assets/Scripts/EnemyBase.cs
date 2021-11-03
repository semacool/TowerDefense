using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    /// <summary>
    /// Маршрут
    /// </summary>
    List<GameObject> way = new List<GameObject>();

    /// <summary>
    /// Количество жизней
    /// </summary>
    Text HealthUI;

    /// <summary>
    /// Денег с уничтожения врага
    /// </summary>
    [SerializeField]float money;

    /// <summary>
    /// Урон врага
    /// </summary>
    [SerializeField]float Damage;

    /// <summary>
    /// Скорость
    /// </summary>
    [SerializeField] int Speed = 10;

    /// <summary>
    /// Количество жизней
    /// </summary>
    [SerializeField] float health = 10f;

    
    /// <summary>
    /// Свойство жизней
    /// </summary>
    public float Health
    {
        get => health;
        set
        {
            health = value;
            HealthUI.text = health.ToString("#0.#");
            if (health <= 0)
            {
                Death();
            }
        }
    }

    float MaxHealth;

    /// <summary>
    /// Объект взрыва
    /// </summary>
    [SerializeField] GameObject BoomAnimation;

    /// <summary>
    /// Объект анимации
    /// </summary>
    Animator animator;

    /// <summary>
    /// Точка маршрута
    /// </summary>
    public GameObject WayTarget;

    void Start()
    {
        var allWay = GameObject.FindGameObjectsWithTag("Way");
        foreach (var way in allWay.ToList())
        {   
            this.way.Add(way);
        }
        
        HealthUI = gameObject.GetComponentsInChildren<Text>()[0];
        var hard = PlayerPrefs.GetInt(SettingsState.HARD_LEVEL, 2);
        Damage = Damage * hard;
        Health = health;
        MaxHealth = health;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(WayTarget == null)
        {
            WayTarget = way.Find(e => e.GetComponent<Way>().WayIndex == way.Min(r => r.GetComponent<Way>().WayIndex));
            Rorate();
        }
        var dir = WayTarget.transform.position - transform.position;

        if (dir.x > 0.3f || dir.x < -0.3f)
        {
            dir.y = 0;
        }
        
        transform.position += dir.normalized * Time.deltaTime * Speed;
        if (Vector3.Distance(transform.position, WayTarget.transform.position) < 0.3f)
        {
            
            way.Remove(WayTarget);
            WayTarget = null;
        }
        CheckDestroy();

    }

    /// <summary>
    /// Поворот
    /// </summary>
    void Rorate()
    {
        Vector2 bulletOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 targetOnScreen = Camera.main.WorldToViewportPoint(WayTarget.transform.position);
        var diff = bulletOnScreen - targetOnScreen;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180f);
    }

    /// <summary>
    /// Проверка на разрушение
    /// </summary>
    void CheckDestroy()
    {
        if (way.Count == 0)
        {
            StateLevel.Get.Damaged(Damage);
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Уничтожение врага
    /// </summary>
    void Death()
    {
        Instantiate(BoomAnimation, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
        StateLevel.Get.Money += money;
    }
    /// <summary>
    /// Принять урон
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        Health -= damage;
        animator.Play("Damaged");
    }
}
