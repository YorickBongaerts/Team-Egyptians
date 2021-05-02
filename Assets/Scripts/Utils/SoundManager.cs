using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource ButtonTap;
    public AudioSource Win;
    public AudioSource Lose;
    public AudioSource CollectArtifact;
    public AudioSource TitleScreenBGM; //1
    public AudioSource HubBGM; //2
    public AudioSource MinigameBGM; //3
    public int CurrentBGM = 0;

    public void PlayButtonTap()
    {
        ButtonTap.Play();
    }
    public void PlayWin()
    {
        Win.Play();
    }
    public void PlayLose()
    {
        Lose.Play();
    }
    public void PlayCollectArtifact()
    {
        CollectArtifact.Play();
    }
    public void PlayMinigameBGM()
    {
        MinigameBGM.Play();
    }
    public void PlayHubBGM()
    {
        HubBGM.Play();
    }
    public void PlayTitleScreenBGM()
    {
        TitleScreenBGM.Play();
    }
}
