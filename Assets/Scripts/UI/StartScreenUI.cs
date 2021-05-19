using MexiColeccion.Collection;
using UnityEngine;

namespace MexiColeccion.UI
{
    public class StartScreenUI : BaseUI
    {
        private void Start()
        {
            _soundManager.PlayTitleScreenBGM();
        }

        public void DeleteData()
        {
            _soundManager.PlayButtonTap();
            CollectionDatabase.ClearAllArtifactsData();
            PlayerPrefs.SetInt(CollectionDatabase.PainterVideo, 0);
            PlayerPrefs.SetInt(CollectionDatabase.MemoryVideo, 0);
        }
    }
}