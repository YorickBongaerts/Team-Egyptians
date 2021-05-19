using System;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Utils
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource
            _buttonTap
            , _win
            , _lose
            , _collectArtifact
            , _titleScreenBGM //1
            , _hubBGM //2
            , _minigameBGM
            ,_wrong
            ,_correct; //3

        [SerializeField] private int CurrentBGM = 0;
        [SerializeField] private Slider _backgroundSlider, _sfxSlider;

        private static readonly string FirstTime = "FirstTime"; // first playthrough
        private static readonly string BackgroundVolume = "BackgroundVolume"; // background volume
        private static readonly string SFXVolume = "SFXVolume"; // sound effects volume
        private float _backgroundVolume, _sfxVolume;

        private void Awake()
        {
            if (!_backgroundSlider && !_sfxSlider)
            {
                if (PlayerPrefs.HasKey(BackgroundVolume))
                {
                    _titleScreenBGM.volume = PlayerPrefs.GetFloat(BackgroundVolume);
                    return;
                }
                _titleScreenBGM.volume = 0.25f;
                return;
            }

            if (PlayerPrefs.GetInt(FirstTime) == 0)
            {
                _backgroundVolume = 0.25f;
                _sfxVolume = 0.5f;
                SetSliderValues();
                SaveSettings();
                PlayerPrefs.SetInt(FirstTime, 1);
            }
            else
            {
                _backgroundVolume = PlayerPrefs.GetFloat(BackgroundVolume);
                _sfxVolume = PlayerPrefs.GetFloat(SFXVolume);
                SetSliderValues();
            }
        }

        private void OnDestroy()
        {
            SaveSettings();
        }

        public void OnVolumeChanged()
        {
            ChangeVolumeIfSourceExists(_titleScreenBGM, "bgm");
            ChangeVolumeIfSourceExists(_hubBGM, "bgm");
            ChangeVolumeIfSourceExists(_minigameBGM, "bgm");

            ChangeVolumeIfSourceExists(_correct, "sfx");
            ChangeVolumeIfSourceExists(_wrong, "sfx");
            ChangeVolumeIfSourceExists(_collectArtifact, "sfx");
            ChangeVolumeIfSourceExists(_lose, "sfx");
            ChangeVolumeIfSourceExists(_win, "sfx");
            ChangeVolumeIfSourceExists(_buttonTap, "sfx");
        }

        internal void PlayButtonTap()
        {
            _buttonTap.Play();
        }

        internal void PlayWin()
        {
            _win.Play();
        }

        internal void PlayLose()
        {
            _lose.Play();
        }

        internal void PlayCollectArtifact()
        {
            _collectArtifact.Play();
        }

        internal void PlayMinigameBGM()
        {
            _minigameBGM.Play();
        }

        internal void PlayHubBGM()
        {
            _hubBGM.Play();
        }

        internal void PlayTitleScreenBGM()
        {
            _titleScreenBGM.Play();
        }

        internal void PlayWrong()
        {
            _wrong.Play();
        }

        internal void PlayCorrect()
        {
            _correct.Play();
        }

        private void SetSliderValues()
        {
            _backgroundSlider.value = _backgroundVolume;
            _sfxSlider.value = _sfxVolume;
        }

        private void SaveSettings()
        {
            if (_backgroundSlider && _sfxSlider)
            {
                PlayerPrefs.SetFloat(BackgroundVolume, _backgroundSlider.value);
                PlayerPrefs.SetFloat(SFXVolume, _sfxSlider.value);
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus && PlayerPrefs.HasKey(BackgroundVolume) && PlayerPrefs.HasKey(SFXVolume))
            {
                SaveSettings();
            }
        }

        private void ChangeVolumeIfSourceExists(AudioSource source, string audioType)
        {
            if (!source)
                return;

            if (audioType.Equals("sfx"))
            {
                source.volume = _sfxSlider.value;
            }
            else
            {
                source.volume = _backgroundSlider.value;
            }
        }
    }
}