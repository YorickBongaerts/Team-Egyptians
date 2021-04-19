using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColleccion.UI
{
    public class MinigameBaseUI : BaseUI
    { 
        public void OnRetry()
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
        }
    }
}


