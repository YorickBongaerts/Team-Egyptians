using UnityEngine;

namespace MexiColeccion.Minigames.Memory
{
    public class MainCard : MonoBehaviour
    {
        [SerializeField] public SceneController controller;
        [SerializeField] private GameObject Card_Back;
        public bool IsActive = true;

        //public void AfterClick()
        //{
        //    if (Card_Back.activeSelf && controller.canReveal)
        //    {
        //        Card_Back.SetActive(false);
        //        controller.CardRevealed(this);
        //    }
        //}

        private int _id;
        public int id
        {
            get { return _id; }
        }

        public void ChangeSprite(int id, Sprite image)
        {
            _id = id;
            GetComponent<SpriteRenderer>().sprite = image; //This gets the sprite renderer component and changes the property of it's sprite!
        }

        public void Unreveal()
        {
            Card_Back.SetActive(true);
        }
    }
}