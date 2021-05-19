using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var image = GetComponent<Image>();
        image.enabled = false;
    }
}
