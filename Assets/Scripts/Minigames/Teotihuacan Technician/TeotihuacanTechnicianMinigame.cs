using UnityEngine;

namespace MexiColeccion.Minigames.Teotihuacan
{
    public class TeotihuacanTechnicianMinigame : MinigameBaseClass
    {
        // TODO: remove if this is not going to be used

        protected sealed override void ScoreSystem() // --> could be a seperate class
        {
            //Implementing the scoresystem of the minigame base class
        }

        private void GetPaintingFromDatabase(GameObject painting)
        {
            //The texture and dimensions of the artifact as a painting are collected from the database
        }

        private void ChangeTexture()
        {
            //Change the texture of the object based on what the player is drawing

            //Possible reference: https://youtu.be/FR618z5xEiM?t=347
        }

        private void AccuracyCheck()
        {
            //Check how close the player-drawn texture matches with the original
        }

        private void InkManager()
        {
            //Keep up with how much the player has drawn and how much they can still draw
        }
    }
}