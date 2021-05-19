using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    List<RectTransform> way = new List<RectTransform>();
    Text HealthUI;

    [SerializeField] int Speed = 10;
    [SerializeField] float Health = 10;
        
    public int WayIndex = 0;
    void Start()
    {
        var allWay = GameObject.FindWithTag("Way");
        foreach (var way in allWay.GetComponentsInChildren<RectTransform>())
        {
            this.way.Add(way);
        }
        HealthUI = gameObject.GetComponentsInChildren<Text>()[0];
        HealthUI.text = Health.ToString();

    }
    void Update()
    {
        var dir = way[WayIndex].transform.position - transform.position;

        if (dir.x > 0.3f)
        {
            dir.y = 0;
        }

        transform.Translate(dir.normalized * Time.deltaTime * Speed);
        if (Vector3.Distance(transform.position, way[WayIndex].transform.position) < 0.3f)
        {
            WayIndex++;
        }
        if (WayIndex == way.Count)
        {
            Destroy(gameObject);
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        HealthUI.text = Health.ToString();
    }
}
