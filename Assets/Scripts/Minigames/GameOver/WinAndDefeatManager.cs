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
                _scoreDisplay.text = CollectionDataBase.PlayerScore + "%";
                //other code depending on minigame
            }
            
        }

    }
}


