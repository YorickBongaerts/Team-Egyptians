using MexiColeccion.Collection;
using MexiColeccion.Utils;
using UnityEngine;

namespace MexiColeccion.Minigames
{
    public class GameOverManager : MonoBehaviour
    {
        internal void OnVictory(int score)
        {
            CollectionDatabase.LastGameSceneName = LevelLoader.GetCurrentLevelName();
            CollectionDatabase.PlayerScore = score;
            LevelLoader.LoadNextLevel("VictoryScene", "CrossFade");
        }

        internal void OnDefeat(int score)
        {
            CollectionDatabase.LastGameSceneName = LevelLoader.GetCurrentLevelName();
            CollectionDatabase.PlayerScore = score;
            LevelLoader.LoadNextLevel("DefeatScene", "CrossFade");
        }
    }
}
