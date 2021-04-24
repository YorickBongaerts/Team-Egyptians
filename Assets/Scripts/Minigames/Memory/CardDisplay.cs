using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MexiColeccion.Minigames.Memory
{
    public class CardDisplay : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        private CardType _cardTypeProperties = null;

        [Header("Attributes")]
        [SerializeField]
        private Text nameText;
        [SerializeField]
        private Image ImageFront;
        [SerializeField]
        private Image ImageBack;

        private GameObject CardsContainer;

        public SceneController sceneController;

        public void Initialize(CardType cardType)
        {
            _cardTypeProperties = cardType;

            //nameText = GetComponent<Text>();
            nameText.text = _cardTypeProperties.Cardname;

            //ImageFront = GetComponent<Image>();
            ImageFront.sprite = _cardTypeProperties.ImageFront;

            //ImageBack = GetComponent<Image>();
            ImageBack.sprite = _cardTypeProperties.ImageBack;

            CardsContainer = GameObject.FindGameObjectWithTag("CardsContainer");
            transform.SetParent(CardsContainer.transform);

            //hides the image of the card
            Transform frontImage = transform.GetChild(1);
            frontImage.gameObject.SetActive(false);

            sceneController = GameObject.FindObjectOfType<SceneController>();
        }

        private void Delete()
        {
            Destroy(gameObject);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(eventData.pressPosition);
            //make sure this is a general scene controller
            //sceneController.AfterClick();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("IDC BITCHES");
        }
    }
}