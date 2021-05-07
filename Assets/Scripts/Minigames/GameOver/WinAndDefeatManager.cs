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


        // Start is called before the first frame update
        void Start()
        {
            if(CollectionDataBase.LastGameSceneName == CollectionDataBase.MemoryMiniGame)
            {
                _scoreDisplay.text = CollectionDataBase.PlayerScore.ToString();
            }

            if(CollectionDataBase.LastGameSceneName == CollectionDataBase.PainterMinigame)
            {
                _scoreDisplay.text = CollectionDataBase.PlayerScore + "%";
            }
            
        }

    }
}


