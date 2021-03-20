using UnityEngine;

namespace MexiColleccion.Hub
{
    public class HubScript : MonoBehaviour
    {

        private void MinigameSelector() // --> seperate class
        {
            //Selection screen for the minigames
            //Needs to be made so it allows an easy implementation of potential extra minigames in the future
        }

        private void SceneManagement()
        {
            //Cleanup for scenes
        }

        public void LoadHub() // --> seperate class that controls game state
        {
            //Loads the hub with the selection screens
            //Upon start up?
        }

        private void LoadMinigame(string minigame) // could be another parameter type
        {
            //Loads the selected minigame
            // This calls StartMinigame() from the base class?
        }

        private void ChooseRandomArtifact() //Link/difference with the method in the MinigameBaseClassScript? --> let the minigame base class handle this
        {
            //Chooses a random artifact which will be collectible in the previously loaded minigame
            //Artifact that is chosen should not be already collected
        }

        private void ArtifactViewer() // --> seperate class
        {
            //Viewer for the artifacts
            //Needs to be easily expandable for more artifacts
        }


    }
}