using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : MonoBehaviour
{

    public Button ExitButton;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat(SettingsState.VOLUME_LEVEL, 0.5f);
        ExitButton.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
