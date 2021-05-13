using UnityEngine;

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
            , _minigameBGM; //3

        [SerializeField] private int CurrentBGM = 0;

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
    }
}