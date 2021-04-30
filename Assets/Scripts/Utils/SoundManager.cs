using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource ButtonTap;
    public AudioSource Win;
    public AudioSource Lose;
    public AudioSource CollectArtifact;
    public AudioSource HubBGM;
    public AudioSource MinigameBGM;
    public AudioSource TitleScreenBGM;

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
