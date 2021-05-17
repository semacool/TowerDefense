using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    List<RectTransform> way = new List<RectTransform>();

    [SerializeField] int Speed = 10;
    int wayIndex = 0;
    void Start()
    {
        var allWay = GameObject.FindWithTag("Way");
        foreach (var way in allWay.GetComponentsInChildren<RectTransform>())
        {
            this.way.Add(way);
        }
    }

    void Update()
    {
        var dir = way[wayIndex].transform.position - transform.position;

        if (dir.x > 0.3f)
        {
            dir.y = 0;
        }

        transform.Translate(dir.normalized * Time.deltaTime * Speed);


        if (Vector3.Distance(transform.position,way[wayIndex].transform.position) < 0.3f)
        {
            wayIndex++;
        }

        if (wayIndex == way.Count)
        {
            Destroy(this);
        }
    }
}
