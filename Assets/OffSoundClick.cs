using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class OffSoundClick : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
        AudioListener.volume = AudioListener.volume == 0? PlayerPrefs.GetFloat(SettingsState.VOLUME_LEVEL,0.5f) : 0 ;
    }

}
