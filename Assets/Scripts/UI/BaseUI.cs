using MexiColeccion.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace MexiColeccion.UI
{
    public class BaseUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _optionsUI;
        [SerializeField] private List<GameObject> _activeUI;
        [SerializeField] protected SoundManager _soundManager;
        [SerializeField] private Timer timer;

        private bool _isInOptions = false;

        // should be public in order to be called from inside the inspector
        public void OnMainHubEnter()
        {
            Debug.Log("Now entering main hub");
            // TODO: might want to change the animation type
            LevelLoader.LoadNextLevel("MainHub");
            Time.timeScale = 1;
        }

        // should be public in order to be called from inside the inspector
        public void OnRestartUp()
        {
            Debug.Log("Restarting Scene");
            // TODO: might want to change the animation type
            LevelLoader.LoadNextLevel(LevelLoader.GetCurrentLevelName(), "CrossFade");
            Time.timeScale = 1;
        }

        // should be public in order to be called from inside the inspector
        public void OnOptionsClick()
        {
            if (_isInOptions == false)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
                foreach (GameObject ui in _optionsUI)
                {
                    ui.SetActive(true);
                }

                foreach (GameObject ui in _activeUI)
                {
                    ui.SetActive(false);
                }
                _isInOptions = true;
                if (timer)
                {
                    timer.IsTimerRunning = false;
                }
            }
            _soundManager.PlayButtonTap();
        }

        // should be public in order to be called from inside the inspector
        public void OnContinueClick()
        {
            if (_isInOptions == true)
            {
                if (LevelLoader.GetCurrentLevelName() != "MainHub")
                {
                    Screen.sleepTimeout = SleepTimeout.NeverSleep;
                }
                foreach (GameObject ui in _optionsUI)
                {
                    ui.SetActive(false);
                }

                foreach (GameObject ui in _activeUI)
                {
                    ui.SetActive(true);
                }
                _isInOptions = false;
                if (timer)
                {
                    timer.IsTimerRunning = true;
                }
            }
            _soundManager.PlayButtonTap();
        }

        // should be public in order to be called from inside the inspector
        public void OnQuitClick()
        {
            _soundManager.PlayButtonTap();
            if (LevelLoader.GetCurrentLevelName() != "MainHub")
            {
                OnMainHubEnter();
            }
            else
            {
                Application.Quit();
            }
        }
    }
}