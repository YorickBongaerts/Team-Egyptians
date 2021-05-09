//using System;
using MexiColeccion.Collection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames
{
    public class VictoryManager : MonoBehaviour
    {
        private List<string> _artifacts = new List<string>();
        [SerializeField] private List<Sprite> _artifactPictures = new List<Sprite>();

        public Text Message;
        public Image Artifact;

        private void Start()
        {
            foreach (string s in CollectionDataBase.GetMinigameArtifactNames(CollectionDataBase.LastGameSceneName))
            {
                _artifacts.Add(s);
            }

            GetArtifact(_artifacts);
        }

        private void GetArtifact(List<string> artifactList)
        {
            for (int i = artifactList.Count - 1; i >= 0; i--) // remove the artifacts the player has aleady won
            {
                if (PlayerPrefs.GetInt(artifactList[i]) != 0) // this means it has already been collected
                {
                    artifactList.RemoveAt(i);
                    _artifactPictures.RemoveAt(i);
                }
            }

            if (artifactList.Count == 0)
            {
                Message.text = "You Won!";
                Artifact.gameObject.SetActive(false);
            }
            else //collect new artifact
            {
                int r = Random.Range(0, artifactList.Count);

                PlayerPrefs.SetInt(artifactList[r], 1); // 1 means it has been collected

                Artifact.sprite = _artifactPictures[r];

                Message.text = "You Won a new artifact: " + artifactList[r] + "!";
            }
        }
    }
}