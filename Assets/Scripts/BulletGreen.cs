using System.Collections;
using UnityEngine;

/// <summary>
/// обновлённая логика класса для зелёной пули (лазер)
/// </summary>
public class BulletGreen : Bullet
{
    RectTransform RectTransform;
    private void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        RectTransform.sizeDelta = new Vector2(1f, (target.transform.position - transform.position).magnitude / 7f);
        yield return new WaitForSeconds(0.4f);
        Hit();
    }

    public override void LogicUpdate()
    {

    }
}
