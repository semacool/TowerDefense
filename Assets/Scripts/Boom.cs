using System.Collections;
using UnityEngine;


/// <summary>
/// Создания взрыва после смерти врага
/// </summary>
public class Boom : MonoBehaviour
{
    float seconds = 0.5f;

    private void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
