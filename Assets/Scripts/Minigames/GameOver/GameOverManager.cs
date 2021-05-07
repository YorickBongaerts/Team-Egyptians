using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.Minigames
{
    public class GameOverManager : MonoBehaviour
    {
        public void OnVictory(int score)
        {
            CollectionDataBase.LastGameSceneName = SceneManager.GetActiveScene().name;
            CollectionDataBase.PlayerScore = score;
            SceneManager.LoadScene("VictoryScene");

        }

        public void OnDefeat(int score)
        {
            CollectionDataBase.LastGameSceneName = SceneManager.GetActiveScene().name;
            CollectionDataBase.PlayerScore = score;
            SceneManager.LoadScene("DefeatScene");

        }
    }
}
