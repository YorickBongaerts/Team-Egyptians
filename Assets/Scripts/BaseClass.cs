using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    //Thibo and Vincent
    //make a base class for both minigames

    //Thibo check for the artist minigame
    //vincent check for the memory minigame

    //delta class??


    private bool _isGameActive;


    public void StartMinigame()
    {
        //start the minigame

        _isGameActive = true;
    }

    public void RandomArtifact()
    {
        //select an artifact randomly from the dictionary of artifacts
        //prompt this artifact to be rewarded to the player (ui?)
    }

    public void WinMinigame()
    {
        //conditions on when to win the minigame
        //return true if won
    }

    public void CollectArtifact()
    {
        //get the result of the RandomArtifact class
        //remove this selected artifact from the dictionary
    }

    public void LoseMinigame()
    {
        //conditions on when to lose the minigame
        //return true if lost
    }

    public void EndMinigame()
    {
        //end condition of the minigame
        //based on win or lose minigame
        //show right ui/scene
    }

    public void UI()
    {
        //timer
        //buttons?
    }
}
