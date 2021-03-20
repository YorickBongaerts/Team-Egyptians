using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text nameText;
    public Image ImageFront;
    public Image ImageBack;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.Cardname;
        ImageFront.sprite = card.ImageFront;
        ImageBack.sprite = card.ImageBack;

        //hides the image of the card
        Transform frontImage = transform.GetChild(1);
        frontImage.gameObject.SetActive(false);
    }

}
