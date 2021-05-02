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
            DeleteDataPerMiniGame(CollectionDataBase.MemoryArtifacts);
            DeleteDataPerMiniGame(CollectionDataBase.PainterArtifacts);
        }

        private static void DeleteDataPerMiniGame(string[] artifacts)
        {
            foreach (string s in artifacts)
            {
                PlayerPrefs.SetInt(s, 0);
                Debug.Log(s + " " + PlayerPrefs.GetInt(s));
            }
        }
    }
}