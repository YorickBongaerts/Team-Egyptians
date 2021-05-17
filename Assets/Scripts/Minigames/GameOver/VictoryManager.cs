using MexiColeccion.Collection;
using MexiColeccion.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames
{
    public class VictoryManager : MonoBehaviour
    {
        [SerializeField] private Image _artifactImage;
        [SerializeField] private Text _artifactName;
        [SerializeField] private GameObject _artifactBackground;
        [SerializeField] private SoundManager _soundManager;

        private void Start()
        {
            _soundManager.PlayCollectArtifact();

            GetArtifact(CollectionDatabase.GetMinigameArtifactNames(CollectionDatabase.LastGameSceneName));
        }

        private void GetArtifact(List<string> artifactList)
        {
            // remove the artifacts the player has aleady won
            for (int i = artifactList.Count - 1; i >= 0; i--)
            {
                if (PlayerPrefs.GetInt(artifactList[i]) != 0) // this means it has already been collected
                {
                    artifactList.RemoveAt(i);
                }
            }

            if (artifactList.Count == 0)
            {
                _artifactBackground.SetActive(false);
            }
            //collect new artifact
            else
            {
                int r = Random.Range(0, artifactList.Count);

                PlayerPrefs.SetInt(artifactList[r], 1); // 1 means it has been collected

                ArtifactSO wonArtifact = CollectionDatabase.GetArtifactByName(artifactList[r]
                    , CollectionDatabase.GetMinigameFromScene(CollectionDatabase.LastGameSceneName));
                _artifactImage.sprite = wonArtifact.Image;
                _artifactName.text = wonArtifact.Name;
                print(wonArtifact.Name);
                CollectionDatabase.LastWonArtifact = wonArtifact;
            }
        }
    }
}