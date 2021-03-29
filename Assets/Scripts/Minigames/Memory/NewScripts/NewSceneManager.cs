using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColleccion.Minigames.Memory
{
    public class NewSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject FirstCardSpawn;
        private NewCardScript _firstRevealed;
        private NewCardScript _secondRevealed;
        private Sprite card1Storage;
        private Sprite card2Storage;
        private bool _isAPair = false;
        public const int gridRows = 2;
        public const int gridCols = 3;
        public const float offsetX = 40f;
        public const float offsetY = 50f;
        public GameObject[] _cardPrefabs = new GameObject[3];
        public List<NewCardScript> _cardsList = new List<NewCardScript>();
        private GameObject CardsContainer;
        public bool canReveal
        {
            get { return _secondRevealed == null; }
        }
        private void Start()
        {
            Vector3 startPos = FirstCardSpawn.transform.position; //The position of the first card. All other cards are offset from here.

            int[] numbers = { 0, 0, 1, 1, 2, 2 };
            numbers = ShuffleArray(numbers); //This is a function we will create in a minute!

            for (int i = 0; i < gridCols; i++)
            {
                for (int j = 0; j < gridRows; j++)
                {
                    GameObject card;
                        card = Instantiate(_cardPrefabs[i]);
                        int index = j * gridCols + i;
                        card.GetComponent<NewCardScript>().id = numbers[index];

                        float posX = (offsetX * i) + startPos.x;
                        float posY = (offsetY * j) + startPos.y;
                        card.transform.position = new Vector3(posX, posY, startPos.z);
                }
            }
            //////////////////////////////////////////////////////
            for (int i = 0; i < _cardPrefabs.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var cardPrefab = _cardPrefabs[i];

                    var item = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity);

                    //Debug.Log("Ik ben een " + cardProperty.Cardname + " kaart");
                    CardsContainer = GameObject.FindGameObjectWithTag("CardsContainer");
                    item.transform.SetParent(CardsContainer.transform);

                    _cardsList.Add(item.GetComponent<NewCardScript>());
                }
            }
        }
        public void FlipCard(NewCardScript card1, NewCardScript card2)
        {
            //Flips both the cards after the player has selected 2 face-down cards
            card1Storage = card1.ImageBack;
            card1.ImageBack = card1.ImageFront;
            card1.ImageFront = card1Storage;
            
            card2Storage = card2.ImageBack;
            card2.ImageBack = card2.ImageFront;
            card2.ImageFront = card1Storage;
        }
        private int[] ShuffleArray(int[] numbers)
        {
            int[] newArray = numbers.Clone() as int[];
            for (int i = 0; i < newArray.Length; i++)
            {
                int tmp = newArray[i];
                int r = Random.Range(i, newArray.Length);
                newArray[i] = newArray[r];
                newArray[r] = tmp;
            }
            return newArray;
        }
        public void AfterClick()
        {
            if (_firstRevealed.isActiveAndEnabled && canReveal)
            {
                Debug.Log("REVEAL");
                _firstRevealed.gameObject.SetActive(false);
                CardRevealed(_firstRevealed);
            }
        }

        public void CardRevealed(NewCardScript card)
        {
            if (_firstRevealed == null)
            {
                _firstRevealed = card;
            }
            else
            {
                _secondRevealed = card;
                FlipCard(_firstRevealed, _secondRevealed);
                StartCoroutine(CheckMatch());
            }
        }

        private IEnumerator CheckMatch()
        {
            if (_firstRevealed.id == _secondRevealed.id)
            {
                //_score++;
                //scoreLabel.text = "Score: " + _score;
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                FlipCard(_firstRevealed, _secondRevealed);
            }

            _firstRevealed = null;
            _secondRevealed = null;

        }
}
}
