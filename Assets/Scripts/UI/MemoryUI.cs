using UnityEngine;

namespace MexiColeccion.UI
{
    public class MemoryUI : MinigameBaseUI
    {
        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}