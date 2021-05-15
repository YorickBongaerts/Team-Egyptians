using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Utils
{
    //General Timer class, should replace the timer methods in the minigamebaseclass
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _remainingTime = 120f;
        [SerializeField] private Text timerText;

        internal float RemainingTime => _remainingTime;

        private bool _isTimerRunning = false;
        private float _minutes, _seconds;

        void Start()
        {
            //start timer when script is called
            _isTimerRunning = true;
        }

        private void Update()
        {
            if (_remainingTime > 0 & _isTimerRunning)
            {
                _remainingTime -= Time.deltaTime;
            }
            else
            {
                UnityEngine.Debug.Log("Time had run out");
                _remainingTime = 0;
                _isTimerRunning = false;
            }

            CalculateMinutes();
            CalculateSeconds();

            DisplayTime();
        }

        private void CalculateSeconds()
        {
            _seconds = Mathf.FloorToInt(_remainingTime % 60);
        }

        private void CalculateMinutes()
        {
            _minutes = Mathf.FloorToInt(_remainingTime / 60);
        }

        private void DisplayTime()
        {
            timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
        }
    }
}