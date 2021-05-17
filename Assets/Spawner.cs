using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    /// <summary>
    /// Секунд до старта
    /// </summary>
    [SerializeField] float StartTime = 1f;
    /// <summary>
    /// Количество
    /// </summary>
    [SerializeField] int Count = 1;
    /// <summary>
    /// Раз в минуту
    /// </summary>
    [SerializeField] float Period = 1f;
    /// <summary>
    /// Объект спавна
    /// </summary>
    [SerializeField] private GameObject enemy;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        while (true)
        {
            if (Count < 1)
            {
                StopAllCoroutines();
            }
            else if (StartTime > Time.time)
            {
                Debug.Log(Time.time);
            }
            else
            {
                Count--;
                Instantiate(enemy,transform);
            }
            yield return new WaitForSeconds(Period);
        }
    }
}
