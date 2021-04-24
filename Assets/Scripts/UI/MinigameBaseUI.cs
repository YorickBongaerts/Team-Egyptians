using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.UI
{
    public class MinigameBaseUI : BaseUI
    {
        public void OnRetry()
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
        }
    }
}


