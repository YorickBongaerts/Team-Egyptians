using MexiColeccion.Collection;
using MexiColeccion.Utils;

namespace MexiColeccion.UI
{
    public class MinigameBaseUI : BaseUI
    {
        public void OnRetry()
        {
            _soundManager.PlayButtonTap();
            LevelLoader.LoadNextLevel(CollectionDatabase.LastGameSceneName, "CrossFade");
        }
    }
}


