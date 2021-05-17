using MexiColeccion.Collection;
using MexiColeccion.Utils;
using UnityEngine;

namespace MexiColeccion.Minigames
{
    public class GameOverManager : MonoBehaviour
    {
        // TODO: reset to internal when testing is done
        public void OnVictory(int score)
        {
            CollectionDatabase.LastGameSceneName = LevelLoader.GetCurrentLevelName();
            CollectionDatabase.PlayerScore = score;
            CollectionDatabase.HasWon = true;
            LevelLoader.LoadNextLevel("VictoryScene", "CrossFade");
        }

        internal void OnDefeat(int score)
        {
            CollectionDatabase.LastGameSceneName = LevelLoader.GetCurrentLevelName();
            CollectionDatabase.PlayerScore = score;
            CollectionDatabase.HasWon = false;
            LevelLoader.LoadNextLevel("DefeatScene", "CrossFade");
        }
    }
}
