using System.Collections;
using UnityEngine;

/// <summary>
/// Спавнер врагов
/// </summary>
public class Spawner : MonoBehaviour
{

    /// <summary>
    /// Секунд до старта
    /// </summary>
    [SerializeField] float StartTime = 1f;
    /// <summary>
    /// Количество
    /// </summary>
    public int Count = 1;
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
                yield return new WaitForEndOfFrame();
            }
            if(StartTime < Time.timeSinceLevelLoad)
            {
                Count--;
                Instantiate(enemy,transform);
            }
            yield return new WaitForSeconds(Period);
        }
    }
}
