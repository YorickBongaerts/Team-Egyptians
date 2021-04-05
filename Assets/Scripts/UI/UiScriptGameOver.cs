using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColleccion.UI
{
    public class UiScriptGameOver : UIScript
    { 
        public void OnRetryUp()
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
        }
    }
}


