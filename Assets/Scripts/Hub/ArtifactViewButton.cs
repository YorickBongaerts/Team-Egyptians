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
                string[] artifacts = CollectionDataBase.GetMinigameArtifacts(_playerScript.CurrentPainting.Minigame);
                _maxArtifacts = artifacts.Length;
                for (int i = 0; i < artifacts.Length; i++)
                {
                    string artifactName = artifacts[i];
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
