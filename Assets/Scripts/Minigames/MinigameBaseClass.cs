using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBaseClass : MonoBehaviour
{
    //Thibo and Vincent
    //Make a base class for both minigames

    //Thibo check for the artist minigame
    //Vincent check for the memory minigame

    //Delegates??


    private bool _isGameActive;


    public void StartMinigame()
    {
        //Start the minigame
        //Call and activate the chosen minigame

        _isGameActive = true;
    }

    public void RandomArtifact(GameObject[] minigameSpecificArtifacts) //Link/difference with the method in the HubScript?
    {
        //Select an artifact randomly from the dictionary of artifacts
        //Prompt this artifact to be rewarded to the player (ui?)

        //Chooses a random artifact that has not yet been collected
    }

    public void WinMinigame() //Vague conditions to be overwritten in the minigameSpecificClasses?
    {
        //Conditions on when to win the minigame
        //Return true if won
    }

    public void CollectArtifact()
    {
        //Get the result of the RandomArtifact class
        //Remove this selected artifact from the dictionary
        //Add it to the list of already achieved artifacts
        //Show the artifact that the player gets
    }

    public void LoseMinigame()
    {
        //Conditions on when to lose the minigame
        //Return true if lost  OR return a false for win condition
    }

    public void EndMinigame()
    {
        //End condition of the minigame
        //Based on win or lose minigame
        //Show right ui/scene
    }

    public void Timer()
    {
        //Timer
        //Display in the UI
        //Get an int value, so that it can be specified per minigame
    }

    public void LoseWhenTimeRunsOut()
    {
        //Loses the minigame when the timer reaches 0
    }

    public virtual void ScoreSystem()
    {
        //The score system will hold the scope of the player
        //The way in which the points are calculated varies between minigames and will be coded in their respective scripts

    }
}
