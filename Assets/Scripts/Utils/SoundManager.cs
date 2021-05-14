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
        [SerializeField] private Slider SoundSlider;
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

        public void OnVolumeChanged()
        {
            _correct.volume = SoundSlider.value;
            _wrong.volume = SoundSlider.value;
            _titleScreenBGM.volume = SoundSlider.value;
            _hubBGM.volume = SoundSlider.value;
            _minigameBGM.volume = SoundSlider.value;
            _collectArtifact.volume = SoundSlider.value;
            _lose.volume = SoundSlider.value;
            _win.volume = SoundSlider.value;
            _buttonTap.volume = SoundSlider.value;
        }
    }
}