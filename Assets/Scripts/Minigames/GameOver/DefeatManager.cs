using MexiColeccion.Collection;
using MexiColeccion.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames
{
    public class DefeatManager : MonoBehaviour
    {
        [SerializeField] private Text _scoreDisplay;
        [SerializeField] private int _painterScoreTreshold;
        [SerializeField] private Animator _quetziAnimator;
        [SerializeField] private SoundManager _soundManager;

        private void Start()
        {
            _soundManager.PlayLose();
            
            _quetziAnimator.SetBool("HasWon", CollectionDatabase.HasWon);

            if (CollectionDatabase.LastGameSceneName == CollectionDatabase.GetSceneName(Minigame.Memory))
            {
                _scoreDisplay.text = CollectionDatabase.PlayerScore.ToString() + "/8";

                return;
            }

            if (CollectionDatabase.LastGameSceneName == CollectionDatabase.GetSceneName(Minigame.Painter))
            {
                if (CollectionDatabase.PlayerScore > _painterScoreTreshold)
                    _scoreDisplay.text = CollectionDatabase.PlayerScore + "% > " + _painterScoreTreshold + "%";
                else if (CollectionDatabase.PlayerScore == _painterScoreTreshold)
                    _scoreDisplay.text = CollectionDatabase.PlayerScore + "% = " + _painterScoreTreshold + "%";
                else
                    _scoreDisplay.text = CollectionDatabase.PlayerScore + "% < " + _painterScoreTreshold + "%";

                return;
            }
        }
    }
}


