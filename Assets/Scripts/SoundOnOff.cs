using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField] private GameObject _btnSoundOn;
    [SerializeField] private GameObject _btnSoundOff;
    [SerializeField] private AudioMixerGroup _mixer;

    [SerializeField] private AudioSource[] _audio;

    [SerializeField] private int _soundMode;

    private void Start()
    {
        _audio = FindObjectsOfType<AudioSource>();
        _soundMode = PlayerPrefs.GetInt("SoundMode");

        if (_soundMode == 0)
            SoundOn();
        else SoundOff();
    }
    public void SoundOn()
    {
        _btnSoundOff.SetActive(false);
        _btnSoundOn.SetActive(true);


        _mixer.audioMixer.SetFloat("GameAudio", 0);
        PlayerPrefs.SetInt("SoundMode",0);
    }

    public void SoundOff()
    {
        _btnSoundOff.SetActive(true);
        _btnSoundOn.SetActive(false);


        _mixer.audioMixer.SetFloat("GameAudio", -80);
        PlayerPrefs.SetInt("SoundMode", 1);
    }
}
