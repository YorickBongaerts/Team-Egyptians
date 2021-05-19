using MexiColeccion.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames.Memory
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject _firstCardSpawn;
        [SerializeField] private GameObject[] _cardPrefabs = new GameObject[3];
        [SerializeField] private GameObject _leafPilePrefab;
        [SerializeField] private GameOverManager _gameOverManager;
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private Text _livesText;
        [SerializeField] private GameObject _confettiParticles;

        [SerializeField] private int _gridCols = 4;
        [SerializeField] private int _gridRows = 4;
        [SerializeField] private int _lives = 3;

        private const float OffsetX = 40f;
        private const float OffsetY = 50f;
        
        private List<Card> _cardsList = new List<Card>();
        private Card _firstRevealedCard;
        private Card _secondRevealedCard;
        private GameObject _cardsContainer;
        private GameObject _leavesContainer; // TODO: is this used somewhere?
        private Animator _animator;
        private Sprite _card1Storage;
        private Sprite _card2Storage; // TODO: is this used somewhere?
        private int _amountOfCollectedPairs = 0;
        private int _score = 0;
        private bool _isAPair = false; // TODO: is this used somewhere?

        public bool CanReveal => _secondRevealedCard == null;

        private void Start()
        {
            _soundManager.PlayMinigameBGM();
            //_scoreText.text = _score.ToString();
            _livesText.text = _lives.ToString();

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

            numbers = ShuffleArray(numbers);

            for (int i = 0; i < _gridCols; i++)
            {
                for (int j = 0; j < _gridRows; j++)
                {
                    GameObject card;
                    int index = j * _gridCols + i;
                    card = Instantiate(_cardPrefabs[numbers[index]]);
                    card.GetComponent<Card>().Id = numbers[index];

                    //float posX = (offsetX * i) + startPos.x;
                    //float posY = (offsetY * j) + startPos.y;

                    float posX = card.GetComponent<Card>().Id * OffsetX;
                    float posY = 20 * OffsetY;

                    card.transform.position = new Vector3(posX, posY, startPos.z);

                    GameObject leafPile;
                    leafPile = Instantiate(_leafPilePrefab);
                    _leavesContainer = GameObject.FindGameObjectWithTag("LeafContainer");
                    leafPile.transform.SetParent(card.transform);

                    _cardsContainer = GameObject.FindGameObjectWithTag("CardsContainer");
                    card.transform.SetParent(_cardsContainer.transform);

                    _cardsList.Add(card.GetComponent<Card>());

                    //rescales the cards to fit on the screen well and not be deformed. 
                    card.GetComponent<RectTransform>().localScale = Vector3.one;
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
            foreach (Card card in _cardsList)
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

        private IEnumerator FlipCards(Card card1, Card card2)
        {
            //Flips both the cards after the player has selected 2 face-down cards

            FlipCard(card1);
            FlipCard(card2);
            yield return null;
        }

        private void FlipCard(Card card)
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

        internal void AfterClick(GameObject clickedCard)
        {
            Card revealedCard = clickedCard.GetComponent<Card>();
            _soundManager.PlayLeaf();
            if (_firstRevealedCard == null && CanReveal)
            {
                Debug.Log("REVEAL");
                _firstRevealedCard = revealedCard;
                FlipCard(revealedCard);
                StartCoroutine(PlayLeavesAnimation(revealedCard, true));
            }
            else if (_firstRevealedCard.gameObject != clickedCard && _secondRevealedCard == null)
            {
                Debug.Log("REVEAL 2");
                _secondRevealedCard = revealedCard;
                StartCoroutine(PlayLeavesAnimation(revealedCard, true));
                FlipCard(revealedCard);
                CardsRevealed();
            }
        }

        private IEnumerator PlayLeavesAnimation(Card card, bool playForward)
        {
            _animator = card.transform.GetChild(0).GetComponent<Animator>();
            if (playForward)
            {
                _animator.Play("Swipe Off");
            }
            else
            {
                _animator.Play("Swipe On");
            }
            yield return null;
        }

        private void CardsRevealed()
        {
            if (_firstRevealedCard == null || _secondRevealedCard == null)
                return;

            //StartCoroutine(FlipCards(_firstRevealed, _secondRevealed));
            StartCoroutine(CheckMatch());
        }

        private IEnumerator CheckMatch()
        {
            if (_firstRevealedCard.Id == _secondRevealedCard.Id)
            {
                _score++;
                //_scoreText.text = _score.ToString();

                _soundManager.PlayCorrect();
                Instantiate(_confettiParticles, Vector3.zero, Quaternion.identity);

                Debug.Log("Correct pair");
                yield return new WaitForSeconds(2f);
                Delete(_firstRevealedCard.gameObject, _secondRevealedCard.gameObject);
                _firstRevealedCard = null;
                _secondRevealedCard = null;

                CheckForWin();
            }
            else
            {
                _lives--;
                _livesText.text = _lives.ToString();

                _soundManager.PlayWrong();

                yield return new WaitForSeconds(2f);
                StartCoroutine(PlayLeavesAnimation(_firstRevealedCard, false));
                StartCoroutine(PlayLeavesAnimation(_secondRevealedCard, false));
                yield return new WaitForSeconds(1.2f);
                StartCoroutine(FlipCards(_firstRevealedCard, _secondRevealedCard));
                Debug.Log("Incorrect pair");
                _firstRevealedCard = null;
                _secondRevealedCard = null;

                CheckForLoss();
            }
        }

        private void CheckForWin()
        {
            if (_amountOfCollectedPairs == _cardPrefabs.Length)
            {
                Debug.Log("Win");
                _gameOverManager.OnVictory(_score);
            }
        }

        private void CheckForLoss()
        {
            if (_lives <= 0)
            {
                Debug.Log("Loss");
                //_soundManager.PlayLose();
                _gameOverManager.OnDefeat(_score);
            }
        }

        private void Delete(GameObject card1, GameObject card2)
        {
            Destroy(card1.gameObject);
            Destroy(card2.gameObject);
            _amountOfCollectedPairs++;
        }

        private void UpdateCardImage(Card card)
        {
            card.gameObject.GetComponent<Image>().sprite = card.ImageShow;
        }
    }
}
