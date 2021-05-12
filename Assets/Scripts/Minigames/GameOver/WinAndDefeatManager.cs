using MexiColeccion.Collection;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames
{
    public class WinAndDefeatManager : MonoBehaviour
    {
        [SerializeField] private Text _scoreDisplay;
        [SerializeField] private int _painterScoreTreshold;


        void Start()
        {
            if (CollectionDatabase.LastGameSceneName == CollectionDatabase.GetSceneName(Minigame.Memory))
            {
                _scoreDisplay.text = CollectionDatabase.PlayerScore.ToString();
                //other code depending on minigame
            }

            if (CollectionDatabase.LastGameSceneName == CollectionDatabase.GetSceneName(Minigame.Painter))
            {
                if (CollectionDatabase.PlayerScore > _painterScoreTreshold)
                    _scoreDisplay.text = CollectionDatabase.PlayerScore + "% > " + _painterScoreTreshold + "%";
                else
                    _scoreDisplay.text = CollectionDatabase.PlayerScore + "% < " + _painterScoreTreshold + "%";

                //other code depending on minigame
            }

        }

    }
}


