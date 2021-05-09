using MexiColeccion.Collection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.Minigames
{
    public class GameOverManager : MonoBehaviour
    {
        public void OnVictory(int score)
        {
            CollectionDatabase.LastGameSceneName = SceneManager.GetActiveScene().name;
            CollectionDatabase.PlayerScore = score;
            SceneManager.LoadScene("VictoryScene");

        }

        public void OnDefeat(int score)
        {
            CollectionDatabase.LastGameSceneName = SceneManager.GetActiveScene().name;
            CollectionDatabase.PlayerScore = score;
            SceneManager.LoadScene("DefeatScene");

        }
    }
}
