using MexiColeccion.Collection;
using System.Collections;
using System.Collections.Generic;
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
            if(CollectionDataBase.LastGameSceneName == CollectionDataBase.GetSceneName(Minigame.Memory))
            {
                _scoreDisplay.text = CollectionDataBase.PlayerScore.ToString();
                //other code depending on minigame
            }

            if (CollectionDataBase.LastGameSceneName == CollectionDataBase.GetSceneName(Minigame.Painter))
            {
                if(CollectionDataBase.PlayerScore > _painterScoreTreshold)
                    _scoreDisplay.text = CollectionDataBase.PlayerScore + "% > " + _painterScoreTreshold + "%";
                else
                    _scoreDisplay.text = CollectionDataBase.PlayerScore + "% < " + _painterScoreTreshold + "%";

                //other code depending on minigame
            }
            
        }

    }
}


