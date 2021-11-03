using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    [SerializeField] GameObject Level1;
    [SerializeField] GameObject Level2;

    void Start()
    {
        CheckScore(Level1);
        CheckScore(Level2);
        var score1 = PlayerPrefs.GetInt(Level1.name, 0);
        if(score1 < 1)
        {
            Level2.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            Level2.GetComponent<ClickLevel>().enabled = false;
        }

    }



    private void CheckScore(GameObject Level)
    {
        var score = PlayerPrefs.GetInt(Level.name, 0);
        var scoreUI = Level.transform.GetChild(1);
        
        for (int i = 0; i < score; i++)
        {
            scoreUI.GetChild(i).gameObject.SetActive(true);
        }
    }

}
