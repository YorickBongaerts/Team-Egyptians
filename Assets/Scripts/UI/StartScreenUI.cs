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
            CollectionDataBase.ClearAllArtifactsData();
        }
    }
}