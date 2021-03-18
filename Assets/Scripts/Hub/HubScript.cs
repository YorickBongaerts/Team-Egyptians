﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MexiColleccion.Hub
{
    public class HubScript : MonoBehaviour
    {
        private void MinigameSelector()
        {
            //Selection screen for the minigames
            //Needs to be made so it allows an easy implementation of potential extra minigames in the future
        }

        private void SceneManagement()
        {
            //Cleanup for scenes
        }

        public void LoadHub()
        {
            //Loads the hub with the selection screens
            //Upon start up?
        }

        private void LoadMinigame(string minigame) // could be another parameter type
        {
            //Loads the selected minigame
        }

        private void ChooseRandomArtifact() //Link/difference with the method in the MinigameBaseClassScript?
        {
            //Chooses a random artifact which will be collectible in the previously loaded minigame
            //Artifact that is chosen should not be already collected
        }

        private void ArtifactViewer()
        {
            //Viewer for the artifacts
            //Needs to be easily expandable for more artifacts
        }
    }
}