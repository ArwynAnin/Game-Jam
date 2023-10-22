using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }
    public AudioSource audioSource;
    public AudioSource sfxSource;
    public float bgm_volume, sfx_volume;
    public Slider bgm_slider, sfx_slider;

    private void Awake()
    {
        bgm_volume = audioSource.volume;
        sfx_volume = sfxSource.volume;
        bgm_slider.value = bgm_volume;
        sfx_slider.value = sfx_volume;
    }

    public void ChangeBGMVolume()
    {
        bgm_volume = bgm_slider.value;
        audioSource.volume = bgm_volume;
    }
    public void ChangeSFXVolume()
    {
        sfx_volume = sfx_slider.value;
        sfxSource.volume = sfx_volume;
    }
}
