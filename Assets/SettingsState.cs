using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsState : MonoBehaviour
{
    public static string VOLUME_LEVEL = "VolumeLevel";
    public static string HARD_LEVEL = "HardLevel";

    public Slider Slider;
    public Button ButtonLevel;
    public Button ButtonSave;
    public int level;
    public float volume;

    private void Start()
    {
        ButtonLevel.onClick.AddListener(ChangeLevel);
        Slider.onValueChanged.AddListener(Volume);
        ButtonSave.onClick.AddListener(SaveSettings);
        level = PlayerPrefs.GetInt("HardLevel", 2);
        volume = PlayerPrefs.GetFloat("VolumeLevel", 0.5f);
        ChangeTextButton();
        Slider.value = volume;
    }

    private void Volume(float volume)
    {
        AudioListener.volume = Slider.value;
    }

    private void ChangeLevel()
    {
        ButtonLevel.GetComponent<AudioSource>().Play();
        level = level + 1 > 3 ? 1 : level + 1;
        ChangeTextButton();
    }

    private void ChangeTextButton()
    {
        switch (level)
        {
            case 1:
                ButtonLevel.transform.GetChild(0).GetComponent<Text>().text = "Лёгкий";
                break;
            case 2:
                ButtonLevel.transform.GetChild(0).GetComponent<Text>().text = "Средний";
                break;
            case 3:
                ButtonLevel.transform.GetChild(0).GetComponent<Text>().text = "Тяжёлый";
                break;
        }
    }

    public void SaveSettings()
    {
        ButtonSave.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("HardLevel", level);
        PlayerPrefs.SetFloat("VolumeLevel", AudioListener.volume);
    }


}
