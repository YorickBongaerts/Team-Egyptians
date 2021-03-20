using System.Collections;
using System.Collections.Generic;
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
            if (Pressed)
                inkPercentage -= 10 * Time.deltaTime;

            else
                if(inkPercentage <= maxInkPercentage)
                inkPercentage += 10 * Time.deltaTime;
        }
    }
}

