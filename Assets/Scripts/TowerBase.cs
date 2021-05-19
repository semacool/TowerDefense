using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    [SerializeField] float timeAttack => 10 / attackSpeed;
    GameObject target;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            if (target == null)
            {
                FindTarget();
            }

            if (target != null)
            {
                Shoot(target.GetComponent<EnemyBase>());
            }
            yield return new WaitForSeconds(timeAttack);
        }
    }

    private void FindTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        var way = GameObject.FindGameObjectsWithTag("Way").ToList().Last();
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

    private void Shoot(EnemyBase enemy)
    {
        Debug.Log("Выстрел!");
        enemy.TakeDamage(damage);

    }
}

