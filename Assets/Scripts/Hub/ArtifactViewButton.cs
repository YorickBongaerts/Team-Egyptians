using MexiColeccion.Collection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Hub
{
    public class ArtifactViewButton : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour _playerScript;
        private int _maxArtifacts;

        internal int MaxArtifacts => _maxArtifacts;

        internal int ArtifactsCollected
        {
            get
            {
                int count = 0;
                List<string> artifactNames = CollectionDatabase.GetMinigameArtifactNames(_playerScript.CurrentPainting.Minigame);
                _maxArtifacts = artifactNames.Count;

                for (int i = 0; i < artifactNames.Count; i++)
                {
                    string artifactName = artifactNames[i];
                    if (PlayerPrefs.GetInt(artifactName) == 1)
                        count++;
                }
                return count;
            }
        }

        private void OnEnable()
        {
            GetComponentInChildren<Text>().text = $"{ArtifactsCollected}/{_maxArtifacts}";
            GetComponent<Button>().interactable = _maxArtifacts > 0;
        }
    }
}
