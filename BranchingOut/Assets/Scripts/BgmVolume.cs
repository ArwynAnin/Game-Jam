using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmVolume : MonoBehaviour
{
    AudioSource bgmSource;
    public Volumes bgm;

    private void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmSource.volume = bgm.volume;
    }
}
