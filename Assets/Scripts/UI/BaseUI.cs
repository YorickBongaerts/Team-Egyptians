using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColleccion.UI
{
    public class BaseUI : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _optionsUI;

        [SerializeField]
        private List<GameObject> _activeUI;

        private bool _isInOptions = false;

        public void OnMainHubEnter()
        {
            Debug.Log("Now entering main hub");
            SceneManager.LoadScene("MainHub");
            Time.timeScale = 1;
        }

        public void OnRestartUp()
        {
            Debug.Log("Restarting Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        public void OnOptionsClick()
        {
            if (_isInOptions == false)
            {

                foreach (GameObject ui in _optionsUI)
                {
                    ui.SetActive(true);
                }

                foreach (GameObject ui in _activeUI)
                {
                    ui.SetActive(false);
                }
                _isInOptions = true;
                Time.timeScale = 0;
            }
        }

        public void OnContinueClick()
        {
            if (_isInOptions == true)
            {

                foreach (GameObject ui in _optionsUI)
                {
                    ui.SetActive(false);
                }

                foreach (GameObject ui in _activeUI)
                {
                    ui.SetActive(true);
                }
                _isInOptions = false;
                Time.timeScale = 1;
            }
        }

        public void OnQuitClick()
        {
            Application.Quit();
        }

    }
}