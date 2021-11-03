using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Состояние уровня
/// </summary>
public class StateLevel : MonoBehaviour
{

    /// <summary>
    /// реализация singleton
    /// </summary>
    public static StateLevel Get;

    public int CountEnemyInSpawners {

        get {

            var sum = 0;
            foreach (var item in FindObjectsOfType<Spawner>())
            {
                sum += item.Count;
            }
            return sum;
        } 
    }

    [SerializeField] int Level;

    /// Количество денег
    /// </summary>
    float money;
    public float Money
    {
        get => money;
        set
        {
            money = value;
            MoneyUI.text = Util.ChangeText(MoneyUI.text, money.ToString("##.##"));
        }
    }

    /// <summary>
    /// Количество жизней
    /// </summary>
    float health;
    public float Health
    {
        get => health;
        set
        {
            health = value;
            if (value < 0) health = 0;
            HealthUI.text = Util.ChangeText(HealthUI.text, health.ToString("##.##"));
        }
    }


    public Text TimerUI;
    public Text MoneyUI;
    public Text HealthUI;


    [SerializeField] GameObject GameOverSolid;
    [SerializeField] GameObject WinSolid;

    /// <summary>
    /// Получение урона от врагов
    /// </summary>
    /// <param name="damage"></param>
    public void Damaged(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameOverSolid.SetActive(true);
    }

    private void WinOver()
    {
        WinSolid.SetActive(true);
        var score = 0;
        if (Health <= 10) score = 1;
        if (Health <= 25 && Health > 10) score = 2;
        if (Health <= 30 && Health > 25) score = 3;
        PlayerPrefs.SetInt($"Level{Level}", score);

        var scoreUI = WinSolid.transform.GetChild(3);
        for (int i = 0; i < score; i++)
        {
            scoreUI.GetChild(i).gameObject.SetActive(true);
        }

    }

    private IEnumerator CheckWin()
    {
        while (true)
        {
            if (CountEnemyInSpawners < 1 && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                if(Health > 0) WinOver();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void Awake()
    {
        Get = this;
        Money = 100f;
        Health = 30f;
        Time.timeScale = 1;
        AudioListener.volume = PlayerPrefs.GetFloat(SettingsState.VOLUME_LEVEL);
        StartCoroutine(CheckWin());
    }

    void Update()
    {
        
        TimerUI.text = TimeSpan.FromSeconds(Time.timeSinceLevelLoad).ToString(@"mm\:ss");
    }

}
