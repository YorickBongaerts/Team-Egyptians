using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.Minigames
{
    public class GameOverManager : MonoBehaviour
    {
        public void OnVictory()
        {
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("VictoryScene");
        }

        public void OnDefeat()
        {
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("DefeatScene");
        }
    }
}
