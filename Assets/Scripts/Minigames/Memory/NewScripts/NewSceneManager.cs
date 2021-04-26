using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames.Memory
{
    public class NewSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject _firstCardSpawn;
        //[SerializeField] private GameObject[] _cardPrefabs = new GameObject[3];
        [SerializeField] private GameObject[] _cardPrefabs = new GameObject[3];
        [SerializeField] private GameObject _leafPilePrefab;

        [SerializeField] private int _gridCols = 4;
        [SerializeField] private int _gridRows = 4;

        private List<NewCardScript> _cardsList = new List<NewCardScript>();
        private NewCardScript _firstRevealed;
        private NewCardScript _secondRevealed;
        private GameObject _cardsContainer;
        private GameObject _leavesContainer;
        private Animator animator;
        private Sprite _card1Storage;
        private Sprite _card2Storage;
        private const float _offsetX = 40f;
        private const float _offsetY = 50f;
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


            //The position of the first card. All other cards are offset from here.
            Vector3 startPos = _firstCardSpawn.transform.position;

            // change the shuffle array relative to the length of card types
            List<int> numbersList = new List<int>();

            for (int i = 0; i < _cardPrefabs.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    numbersList.Add(i);
                }
            }

            int[] numbers = numbersList.ToArray();

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

                    GameObject leafPile;
                    leafPile = Instantiate(_leafPilePrefab);
                    _leavesContainer = GameObject.FindGameObjectWithTag("LeafContainer");
                    leafPile.transform.SetParent(card.transform);

                    _cardsContainer = GameObject.FindGameObjectWithTag("CardsContainer");
                    card.transform.SetParent(_cardsContainer.transform);

                    _cardsList.Add(card.GetComponent<NewCardScript>());
                    
                    card.GetComponent<RectTransform>().localScale = Vector3.one; //rescales the cards to fit on the screen well and not be deformed.   
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
            StartCoroutine(DisableGridGroup());
        }
        private IEnumerator DisableGridGroup()
        {
            yield return new WaitForEndOfFrame();
            _cardsContainer.GetComponent<GridLayoutGroup>().enabled = false;
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
            _card1Storage = card.ImageHide;
            card.ImageHide = card.ImageShow;
            card.ImageShow = _card1Storage;
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
                FlipCard(revealedCard);
                StartCoroutine(PlayLeavesAnimation(revealedCard, true));
            }
            else if (_firstRevealed.gameObject != clickedCard && _secondRevealed == null)
            {
                Debug.Log("REVEAL 2");
                _secondRevealed = revealedCard;
                StartCoroutine(PlayLeavesAnimation(revealedCard, true));
                FlipCard(revealedCard);
                CardsRevealed();
            }
        }
        public IEnumerator PlayLeavesAnimation(NewCardScript card, bool playForward)
        {
            animator = card.transform.GetChild(0).GetComponent<Animator>();
            if (playForward)
            {
                animator.Play("Swipe Off");
            }
            else
            {
                animator.Play("Swipe On");
            }
            yield return null;
        }
        public void CardsRevealed()
        {
            if (_firstRevealed == null || _secondRevealed == null)
                return;

            //StartCoroutine(FlipCards(_firstRevealed, _secondRevealed));
            StartCoroutine(CheckMatch());
        }

        private IEnumerator CheckMatch()
        {
            if (_firstRevealed.Id == _secondRevealed.Id)
            {
                _score++;
                ScoreText.text = _score.ToString();

                Debug.Log("Correct pair");
                yield return new WaitForSeconds(2f);
                Delete(_firstRevealed.gameObject, _secondRevealed.gameObject);
                _firstRevealed = null;
                _secondRevealed = null;
                CheckForWin();
            }
            else
            {
                Lives--;
                LivesText.text = Lives.ToString();

                yield return new WaitForSeconds(2f);
                StartCoroutine(PlayLeavesAnimation(_firstRevealed,false));
                StartCoroutine(PlayLeavesAnimation(_secondRevealed,false));
                yield return new WaitForSeconds(1.2f);
                StartCoroutine(FlipCards(_firstRevealed, _secondRevealed));
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
            if (Lives <= 0)
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
            card.gameObject.GetComponent<Image>().sprite = card.ImageShow;
        }
        private void SetCardPosition(NewCardScript card)
        {

        }
    }
}
