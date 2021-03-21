using UnityEngine;
using UnityEngine.InputSystem;

namespace MexiColleccion.Minigames.Memory
{
    public class MemoryMinigame : MinigameBaseClass
    {
        //Array of materials
        //each card gets a material assigned based on the index of the array

        [SerializeField]
        private Material[] _materials;

        private void Update()
        {

            SelectCard();
        }

        protected sealed override void ScoreSystem() // --> could be a seperate class
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


            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Clicked card");


                }
            }
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

        private void ScoreIncrease() // --> also part of scoresystem
        {
            //If both cards are the same, increase the score
            //Then remove the cards from the game
        }
    }
}