using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MexiColleccion.Minigames.Memory
{
    public class NewSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject _firstCardSpawn;
        [SerializeField] private GameObject[] _cardPrefabs = new GameObject[3];

        private List<NewCardScript> _cardsList = new List<NewCardScript>();
        private NewCardScript _firstRevealed;
        private NewCardScript _secondRevealed;
        private GameObject _cardsContainer;
        private Sprite _card1Storage;
        private Sprite _card2Storage;
        private const float _offsetX = 40f;
        private const float _offsetY = 50f;
        private const int _gridRows = 2;
        private const int _gridCols = 3;
        private int _amountOfCollectedPairs = 0;
        private bool _isAPair = false;

        private int _score = 0;
        public int Lives = 3;

        public Text ScoreText;
        public Text LivesText;
        public GameOverManager GameOver;

        public bool CanReveal
        {
            get { return _secondRevealed == null; }
        }

        private void Start()
        {

            ScoreText.text = _score.ToString();
            LivesText.text = Lives.ToString();

            Vector3 startPos = _firstCardSpawn.transform.position; //The position of the first card. All other cards are offset from here.

            int[] numbers = { 0, 0, 1, 1, 2, 2 };
            numbers = ShuffleArray(numbers); //This is a function we will create in a minute!

            for (int i = 0; i < _gridCols; i++)
            {
                for (int j = 0; j < _gridRows; j++)
                {
                    GameObject card;
                    int index = j * _gridCols + i;
                    card = Instantiate(_cardPrefabs[numbers[index]]);
                    card.GetComponent<NewCardScript>().Id = numbers[index];

                    //float posX = (offsetX * i) + startPos.x;
                    //float posY = (offsetY * j) + startPos.y;

                    float posX = card.GetComponent<NewCardScript>().Id * _offsetX;
                    float posY = 20 * _offsetY;

                    card.transform.position = new Vector3(posX, posY, startPos.z);

                    _cardsContainer = GameObject.FindGameObjectWithTag("CardsContainer");
                    card.transform.SetParent(_cardsContainer.transform);

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
            _card1Storage = card.ImageBack;
            card.ImageBack = card.ImageFront;
            card.ImageFront = _card1Storage;
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
            if (_firstRevealed == null && CanReveal)
            {
                Debug.Log("REVEAL");
                _firstRevealed = revealedCard;
            }
            else if(_firstRevealed.gameObject != clickedCard && _secondRevealed == null)
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
            if (_firstRevealed.Id == _secondRevealed.Id)
            {
                _score++;
                ScoreText.text = _score.ToString();

                Debug.Log("Correct pair");
                Delete(_firstRevealed.gameObject, _secondRevealed.gameObject);
                _firstRevealed = null;
                _secondRevealed = null;
                CheckForWin();
            }
            else
            {
                Lives--;
                LivesText.text = Lives.ToString();

                yield return new WaitForSeconds(0.5f);
                yield return StartCoroutine(FlipCards(_firstRevealed, _secondRevealed));
                Debug.Log("Incorrect pair");
                _firstRevealed = null;
                _secondRevealed = null;
                CheckForLoss();
            }
        }

        private void CheckForWin()
        {
            if (_amountOfCollectedPairs == _cardPrefabs.Length)
            {
                Debug.Log("Win");
                GameOver.OnVictory();
            }
        }

        private void CheckForLoss()
        {
            if(Lives <= 0)
            {
                Debug.Log("Loss");
                GameOver.OnDefeat();
            }
        }

        private void Delete(GameObject card1, GameObject card2)
        {
            Destroy(_firstRevealed.gameObject);
            Destroy(_secondRevealed.gameObject);
            _amountOfCollectedPairs++; 
        }

        private void UpdateCardImage(NewCardScript card)
        {
            card.gameObject.GetComponent<Image>().sprite = card.ImageFront;
        }
}
}
