using MexiColeccion.Collection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.UI
{
    public class MinigameBaseUI : BaseUI
    {
        public void OnRetry()
        {
            _soundManager.PlayButtonTap();
            SceneManager.LoadScene(CollectionDatabase.LastGameSceneName);
        }
    }
}


