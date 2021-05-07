using MexiColeccion.Collection;
using MexiColeccion.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Hub
{
    public class ArtifactViewButton : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour _playerScript;
        private int _maxArtifacts;

        private int ArtifactsCollected
        {
            get
            {
                int count = 0;
                List<string> artifactNames = CollectionDataBase.GetMinigameArtifactNames(_playerScript.CurrentPainting.Minigame);
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
        }
    }
}
