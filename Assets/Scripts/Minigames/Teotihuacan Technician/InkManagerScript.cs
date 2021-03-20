using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MexiColleccion.Minigames
{
    public class InkManagerScript : MonoBehaviour
    {
        public bool _pressed;
        private string _color;
        public MinigameBaseClass _baseClass;

        private float _inkPercentageGreen = 100; 
        private float _inkPercentageRed = 100; 
        private float _inkPercentageBlue = 100;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            InkPercentage("Green");
        }

        private void InkPercentage(string Color)
        {
            float inkPercentage = 100;
            if(Color == "Green")
            {
                inkPercentage = _inkPercentageGreen;
            }
            if (Color == "Red")
            {
                inkPercentage = _inkPercentageRed;
            }
            if (Color == "Blue")
            {
                inkPercentage = _inkPercentageBlue;
            }
            if (_pressed)
            {
                inkPercentage -= 10 * Time.deltaTime;
            }
            else
            {
                if (inkPercentage <= 100)
                    inkPercentage += 10 * Time.deltaTime;
            }
        }
    }
}
