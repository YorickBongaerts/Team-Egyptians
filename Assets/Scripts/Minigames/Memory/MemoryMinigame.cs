using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColeccion.Minigames.Memory
{
    public class MemoryMinigame : MinigameBaseClass
    {
        //Array of materials
        //each card gets a material assigned based on the index of the array

        [SerializeField]
        private Material[] _materials;
        [SerializeField]
        private Sprite[] _cardFrontSprites;

        private bool _isAPair = false;
        private Sprite _cardBackSprite = null;
        private PointerEventData _eventData = null;
        private List<RaycastResult> _results = new List<RaycastResult>();
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

        }

        public void FlipCard(MainCard card1, MainCard card2)
        {
            //Flips both the cards after the player has selected 2 face-down cards
            //Flip them back if they do not match
            card1.ChangeSprite(card1.id, _cardFrontSprites[card1.id]);
            card2.ChangeSprite(card2.id, _cardFrontSprites[card2.id]);
            _isAPair = CheckIfCorrect(card1, card2);
            if (!_isAPair)
            {
                card1.ChangeSprite(card1.id, _cardBackSprite);
                card2.ChangeSprite(card2.id, _cardBackSprite);
            }
        }

        private bool CheckIfCorrect(MainCard card1, MainCard card2)
        {
            //Check if the player has chosen two cards of the same pair
            if (card1.gameObject.transform.GetComponent<SpriteRenderer>().sprite.name == card1.gameObject.transform.GetComponent<SpriteRenderer>().sprite.name)
            {
                return true;
            }
            else
                return false;
            //ScoreIncrease()
            //Remove the cards from the game in this method instead of the score increase?


            //Check if material is the same of both selected items?
            //maybe through a material ID variable?
        }

        private void ScoreIncrease(MainCard card1, MainCard card2) // --> also part of scoresystem
        {
            //If both cards are the same, increase the score
            //Then remove the cards from the game
            Destroy(card1.gameObject);
            Destroy(card2.gameObject);
        }
    }
}