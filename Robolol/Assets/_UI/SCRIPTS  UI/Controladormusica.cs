using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Controladormusica : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public float initialValue;
    public float volume;

    public AudioSource backgroundMusic;
    public AudioSource soundEffect;

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

        // Ajustar el volumen de la música de fondo
        audioMixer.SetFloat(musicVolumeString, NormalizedVolume(volume));

        // Ajustar el volumen de los efectos de sonido
        if (soundEffect != null)
        {
            soundEffect.volume = volume;
        }
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(musicVolumeString, volume);
        PlayerPrefs.Save();

        // Reproducir un efecto de sonido al guardar la configuración
        if (soundEffect != null)
        {
            soundEffect.Play();
        }
    }

    float NormalizedVolume(float normalizedVolume)
    {
        float minimalRange = 0.0001f;
        float decibels = 20.0f * Mathf.Log10(Mathf.Max(normalizedVolume, minimalRange));

        return decibels;
    }
}
