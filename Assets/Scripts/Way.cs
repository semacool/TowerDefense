using System;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Часть пути
/// </summary>
public class Way : MonoBehaviour, IComparable<Way> , IEquatable<Way>
{
    [SerializeField]public int WayIndex;

    public int CompareTo(Way other)
    {
        return this.WayIndex.CompareTo(other.WayIndex);
    }

    public bool Equals(Way other)
    {
        return Equals(other);
    }

    // Start is called before the first frame update
    void Start()
    {
        var image = GetComponent<Image>();
        image.enabled = false;
    }
}
