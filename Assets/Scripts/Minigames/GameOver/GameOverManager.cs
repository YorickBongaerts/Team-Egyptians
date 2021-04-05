using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
