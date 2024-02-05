using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public float initialValue;
    public float volume;

    private string musicVolumeString = "MusicVolume";

    void Start()
    {
        initialValue = PlayerPrefs.GetFloat(musicVolumeString, 0.5f);
        slider.value = initialValue;
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        volume = slider.value;
        audioMixer.SetFloat(musicVolumeString, NormalizedVolume(volume));
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(musicVolumeString, volume);
        PlayerPrefs.Save();
    }

    float NormalizedVolume(float normalizedVolume)
    {
        float minimalRange = 0.0001f;
        float decibels = 20.0f * Mathf.Log10(Mathf.Max(normalizedVolume, minimalRange));

        return decibels;
    }
}
