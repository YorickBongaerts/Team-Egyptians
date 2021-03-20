using UnityEngine;

namespace MexiColleccion.Minigames
{
    public class InkManagerScript : MonoBehaviour
    {
        public bool Pressed;
        private float inkPercentage;
        private float maxInkPercentage = 100;

        void Start()
        {
            inkPercentage = maxInkPercentage;
        }

        void Update()
        {
        }

        public void OnTouching()
        {
            Debug.Log(inkPercentage);
            if (Pressed)
                inkPercentage -= 10 * Time.deltaTime;

            else
                            if (inkPercentage <= maxInkPercentage)
                inkPercentage += 10 * Time.deltaTime;
        }
    }
}

