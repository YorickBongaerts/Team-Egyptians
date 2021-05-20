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
        [SerializeField] private GameObject _nameObject;
        [SerializeField] private GameObject _artifactBackground;
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private float _timeBetweenRandomWinSwitch;
        [SerializeField] private UIAnimator _uiAnimator;
        [SerializeField] private Animator _quetziAnimator;

        private float _quetziTimer;


        private void Start()
        {
            _soundManager.PlayCollectArtifact();

            GetArtifact(CollectionDatabase.GetMinigameArtifactNames(CollectionDatabase.LastGameSceneName));
        }

        private void Update()
        {
            _quetziTimer -= Time.deltaTime;

            if (_quetziTimer <= 0)
            {
                _quetziTimer = _timeBetweenRandomWinSwitch;
                _quetziAnimator.SetInteger("RandomWin", Random.Range(0, 3));
            }
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
                Destroy(_uiAnimator);
                _artifactBackground.SetActive(false);
                _nameObject.SetActive(false);
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