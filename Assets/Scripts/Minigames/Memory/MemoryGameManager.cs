using System.Collections.Generic;
using UnityEngine;

namespace MexiColleccion.Minigames.Memory
{
    public class MemoryGameManager : MinigameBaseClass
    {
        [SerializeField]
        private GameObject _cardPrefab = null;

        [SerializeField]
        private List<CardType> _cardTypes = new List<CardType>();

        private List<CardDisplay> _cardsList = new List<CardDisplay>();

        void Start()
        {
            for (int i = 0; i < _cardTypes.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var cardProperty = _cardTypes[i];

                    var item = Instantiate(_cardPrefab, new Vector2(0, 0), Quaternion.identity);
                    var cardView = item.GetComponent<CardDisplay>();

                    //Debug.Log("Ik ben een " + cardProperty.Cardname + " kaart");
                    cardView.Initialize(cardProperty);

                    _cardsList.Add(cardView);
                }
            }

            //ShuffleList(_cardsList);

        }

        private static void ShuffleList(List<CardDisplay> randomCardsList)
        {
            for (int i = 0; i < randomCardsList.Count; i++)
            {
                CardDisplay fruitCurrentIndex = randomCardsList[i];
                int randomIndex = Random.Range(i, randomCardsList.Count);
                randomCardsList[i] = randomCardsList[randomIndex];
                randomCardsList[randomIndex] = fruitCurrentIndex;
            }
        }
    }
}