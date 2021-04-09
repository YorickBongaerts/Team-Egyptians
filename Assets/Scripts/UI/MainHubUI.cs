using MexiColleccion.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MexiColleccion.UI
{
    /// <summary>
    /// This is the new version of the UIScriptMainHub Script (deleted)
    /// </summary>
    public class MainHubUI : UIScript
    {
        [SerializeField] private GameObject _playerCharacter;

        internal event EventHandler<OnArrowTappedEventArgs> ArrowTapped;

        public void OnLeftArrowTapped()
        {
            Debug.Log("TappedLeft");
            int direction = -1;

            OnArrowTapped(direction);
        }

        public void OnRightArrowTapped()
        {
            Debug.Log("TappedRight");
            int direction = 1;

            OnArrowTapped(direction);
        }

        private void OnArrowTapped(int direction)
        {
            EventHandler<OnArrowTappedEventArgs> handler = ArrowTapped;
            ArrowTapped?.Invoke(this, new OnArrowTappedEventArgs(direction));
        }
    }

    internal class OnArrowTappedEventArgs
    {
        internal int Direction;

        internal OnArrowTappedEventArgs(int direction)
        {
            Direction = direction;
        }
    }
}
