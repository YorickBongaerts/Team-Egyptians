using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
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
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

}
