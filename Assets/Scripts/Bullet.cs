using UnityEngine;

/// <summary>
/// Скрипт пули
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// Пуля выстрелена
    /// </summary>
    public bool IsShooted = false;

    /// <summary>
    /// Скорость пули
    /// </summary>
    [SerializeField]public float Speed = 20f;

    /// <summary>
    /// Радиус попадания пули
    /// </summary>
    [SerializeField]public float HitRange = 1f;

    /// <summary>
    /// Урон пули
    /// </summary>
    protected float damage = 1f;

    /// <summary>
    /// Цель пули
    /// </summary>
    public GameObject target;

    /// <summary>
    /// Последние положение цели
    /// </summary>
    protected Vector3 vectorTarger;

    void Update()
    {
        LogicUpdate();
    }

    /// <summary>
    /// Логика обнолвения пули
    /// </summary>
    public virtual void LogicUpdate()
    {
        Rorate();
        if (IsShooted)
        {
            if (target != null)
            {
                vectorTarger = target.transform.position;
            }
            var dir = (vectorTarger - transform.position).normalized * Time.deltaTime * Speed;
            transform.position += dir;
        }

        if ((vectorTarger - transform.position).magnitude <= HitRange)
        {
            Hit();
        }
    }

    /// <summary>
    /// Вращение пули
    /// </summary>
    protected void Rorate()
    {
        Vector2 bulletOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 targetOnScreen = Camera.main.WorldToViewportPoint(vectorTarger);
        var diff = bulletOnScreen - targetOnScreen;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }

    /// <summary>
    /// Базовая настройка пули
    /// </summary>
    /// <param name="target"></param>
    /// <param name="damage"></param>
    public void ConfigBullet(GameObject target, float damage)
    {
        this.target = target;
        this.damage = damage;
        IsShooted = true;
    }

    /// <summary>
    /// Пуля попала по врагу
    /// </summary>
    protected void Hit()
    {
        if(target != null)
        {
            var enemy = target.GetComponent<EnemyBase>();
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
