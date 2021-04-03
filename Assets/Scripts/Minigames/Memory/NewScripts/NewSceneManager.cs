using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
                    int index = j * gridCols + i;
                    card = Instantiate(_cardPrefabs[numbers[index]]);
                    card.GetComponent<NewCardScript>().id = numbers[index];

                    //float posX = (offsetX * i) + startPos.x;
                    //float posY = (offsetY * j) + startPos.y;

                    float posX = card.GetComponent<NewCardScript>().id * offsetX;
                    float posY = 20 * offsetY;

                    card.transform.position = new Vector3(posX, posY, startPos.z);

                    CardsContainer = GameObject.FindGameObjectWithTag("CardsContainer");
                    card.transform.SetParent(CardsContainer.transform);

                    _cardsList.Add(card.GetComponent<NewCardScript>());
                }
            }
            //////////////////////////////////////////////////////
            //for (int i = 0; i < _cardPrefabs.Length; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        
            //
            //        //var item = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity);
            //
            //        //Debug.Log("Ik ben een " + cardProperty.Cardname + " kaart");
            //
            //    }
            //}
            foreach (NewCardScript card in _cardsList)
            {
                UpdateCardImage(card);
                FlipCard(card);
                UpdateCardImage(card);
            }

        }
        public IEnumerator FlipCards(NewCardScript card1, NewCardScript card2)
        {
            //Flips both the cards after the player has selected 2 face-down cards

            FlipCard(card1);
            FlipCard(card2);
            yield return null;
        }
        private void FlipCard(NewCardScript card)
        {
            card1Storage = card.ImageBack;
            card.ImageBack = card.ImageFront;
            card.ImageFront = card1Storage;
            UpdateCardImage(card);
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
        public void AfterClick(GameObject clickedCard)
        {
            NewCardScript revealedCard = clickedCard.GetComponent<NewCardScript>();
            if (_firstRevealed == null && canReveal)
            {
                Debug.Log("REVEAL");
                _firstRevealed = revealedCard;
            }
            else if(_firstRevealed.gameObject != clickedCard)
            {
                Debug.Log("REVEAL 2");
                _secondRevealed = revealedCard;
                CardsRevealed();
            }
        }

        public void CardsRevealed()
        {
            if (_firstRevealed == null || _secondRevealed == null)
                return;

                StartCoroutine(FlipCards(_firstRevealed, _secondRevealed));
                StartCoroutine(CheckMatch());
        }

        private IEnumerator CheckMatch()
        {
            if (_firstRevealed.id == _secondRevealed.id)
            {
                //_score++;
                //scoreLabel.text = "Score: " + _score;
                Debug.Log("Correct pair");
                Destroy(_firstRevealed.gameObject);
                Destroy(_secondRevealed.gameObject);
                _firstRevealed = null;
                _secondRevealed = null;
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                yield return StartCoroutine(FlipCards(_firstRevealed, _secondRevealed));
                Debug.Log("Incorrect pair");
                _firstRevealed = null;
                _secondRevealed = null;
            }
        }
        private void UpdateCardImage(NewCardScript card)
        {
            card.gameObject.GetComponent<Image>().sprite = card.ImageFront;
        }
}
}
