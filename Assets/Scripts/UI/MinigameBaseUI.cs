using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.UI
{
    public class MinigameBaseUI : BaseUI
    {
        public void OnRetry()
        {
            _soundManager.PlayButtonTap();
            SceneManager.LoadScene(CollectionDataBase.LastGameSceneName);
        }
    }
}


