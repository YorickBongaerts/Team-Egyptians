using UnityEngine;
using UnityEngine.UI;

namespace MexiColleccion.Utils
{
    //General Timer class, should replace the timer methods in the minigamebaseclass
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float remainingTime = 120f;
        [SerializeField] private bool IsTimerRunning = false;
        [SerializeField] private Text timerText;

        private float minutes, seconds;
        // Start is called before the first frame update

        void Start()
        {
            //start timer when script is called
            IsTimerRunning = true;
        }

        private void Update()
        {
            if (remainingTime > 0 & TimerIsRunning())
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                UnityEngine.Debug.Log("Time had run out");
                remainingTime = 0;
                IsTimerRunning = false;
            }

            CalculateMinutes();
            CalculateSeconds();

            DisplayTime();
        }

        private void CalculateSeconds()
        {
            seconds = Mathf.FloorToInt(remainingTime % 60);
        }

        private void CalculateMinutes()
        {
            minutes = Mathf.FloorToInt(remainingTime / 60);
        }

        private void DisplayTime()
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private bool TimerIsRunning()
        {
            if (IsTimerRunning == true)
                return true;
            return false;
        }
    }
}