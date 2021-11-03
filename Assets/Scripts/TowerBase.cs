using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    /// <summary>
    /// Цена продажи
    /// </summary>
    [SerializeField] public float Sale;

    /// <summary>
    /// Улучшение
    /// </summary>
    [SerializeField] public float UpgradeCost;

    /// <summary>
    /// Урон
    /// </summary>
    [SerializeField] public float damage;
    
    /// <summary>
    /// Скрость атаки
    /// </summary>
    [SerializeField] public float attackSpeed;

    /// <summary>
    /// Дальность атаки
    /// </summary>
    [SerializeField] public float Range;

    /// <summary>
    /// Период атаки
    /// </summary>
    [SerializeField] float timeAttack => 10 / attackSpeed;

    /// <summary>
    /// Пуля башни
    /// </summary>
    [SerializeField] GameObject bullet;

    /// <summary>
    /// Цель башни
    /// </summary>
    GameObject target;

    /// <summary>
    /// Анимация башни
    /// </summary>
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Attack());
    }
    void Update()
    {
        if (target != null)
        {
            Rorate();
        }
        else
        {
            FindTarget();
        }

    }
    /// <summary>
    /// Поворт башни
    /// </summary>
    void Rorate()
    {
        transform.up = Vector3.Lerp(transform.up, (target.transform.position - transform.position), 1f);
    }

    /// <summary>
    /// Стрельба
    /// </summary>
    /// <returns></returns>
    IEnumerator Attack()
    {
        while (true)
        {
            if (target != null)
            {
                if (IsRangeIn(target))
                {
                    Rorate();
                    Shoot();
                    yield return new WaitForSeconds(timeAttack);
                }
                else
                {
                    target = null;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Найти цель
    /// </summary>
    private void FindTarget()
    {
        IEnumerable<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var way = GameObject.FindGameObjectsWithTag("Way").ToList().Last();
        enemies = enemies.Where(e => IsRangeIn(e));
        target = enemies.FirstOrDefault();
        foreach (var enemy in enemies)
        {
            var isCloser = (enemy.transform.position - way.transform.position).magnitude < (target.transform.position - way.transform.position).magnitude;
            if (isCloser)
            {
                target = enemy;
            }
        }
    }

    /// <summary>
    /// объект в дальности атаки
    /// </summary>
    /// <param name="target"></param>
    /// <returns>объект в дальности атаки?</returns>
    bool IsRangeIn(GameObject target)
    {
         return (target.transform.position - transform.position).magnitude <= Range;
    }

    /// <summary>
    /// Выстрел
    /// </summary>
    private void Shoot()
    {
        animator.Play("Shoot");
        var newBullet = Instantiate(bullet, transform.position,transform.rotation,transform.parent);
        var bulletLogic = newBullet.GetComponent<Bullet>();
        bulletLogic.ConfigBullet(target, damage);
    }

    public void Upgrade()
    {
        transform.localScale *= 1.05f;
        UpgradeCost = Util.Round(UpgradeCost * 1.2f);
        Sale = Util.Round(Sale * 1.2f);
        damage = Util.Round(damage * 1.2f);
        Range = Util.Round(Range * 1.1f);
    }
}

