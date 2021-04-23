using UnityEngine;

namespace MexiColleccion.UI
{
    public class StartScreenUI : BaseUI
    {
        public void DeleteData()
        {
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