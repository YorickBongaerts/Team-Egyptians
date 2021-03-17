using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMinigameLogic : MinigameBaseClass
{
    
    public override void ScoreSystem()
    {
        //Implementing the scoresystem of the minigame base class
    }

    private void CheckIfWon()
    {
        //Checks if the player has collected all card pairs
    }    

    private void SelectCard()
    {
        //Selects the card(s) the player touches

        //Input MouseDown(0)
    }    

    private void FlipCard()
    {
        //Flips both the cards after the player has selected 2 face-down cards
        //Flip them back if they do not match
    }

    private void CheckIfCorrect()
    {
        //Check if the player has chosen two cards of the same pair

        //ScoreIncrease()
        //Remove the cards from the game in this method instead of the score increase?

        //Check if material is the same of both selected items?
        //maybe through a material ID variable?
    }

    private void ScoreIncrease()
    {
        //If both cards are the same, increase the score
        //Then remove the cards from the game
    }
}
