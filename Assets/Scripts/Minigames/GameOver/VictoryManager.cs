//using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColleccion.Minigames
{
    public class VictoryManager : MonoBehaviour
    {
        public string MemoryMinigame = "MiniGame-Memory";
        public List<string> MemoryArtifacts = new List<string>(); //artifact name convention is *Minigame*+Artifact+*Number*

        public string PainterMinigame = "Painter";
        public List<string> PainterArtifacts = new List<string>(); //artifact name convention is *Minigame*+Artifact+*Number*

        public Text Message;


        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.GetString("PreviousScene") == MemoryMinigame)
            {
                GetArtifact(MemoryArtifacts);
            }

            if (PlayerPrefs.GetString("PreviousScene") == PainterMinigame)
            {
                GetArtifact(PainterArtifacts);
            }
        }

        private void GetArtifact(List<string> artifactList)
        {
            for (int i = artifactList.Count - 1; i >= 0; i--) // remove the artifacts the player has aleady won
            {
                if (PlayerPrefs.GetInt(artifactList[i]) != 0) //this means it has already been collected
                {
                    artifactList.RemoveAt(i);
                }

            }

            if (artifactList.Count == 0)
            {
                Message.text = "You Won!";
            }
            else //collect new artifact
            {
                int r = Random.Range(0, artifactList.Count);

                PlayerPrefs.SetInt(artifactList[r], 1); // 1 means it has been collected

                Message.text = "You Won a new artifact!";
            }
        }
    }
}