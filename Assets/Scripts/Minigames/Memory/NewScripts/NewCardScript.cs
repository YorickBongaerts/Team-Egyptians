using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColleccion.Minigames.Memory
{
    //[CreateAssetMenu(fileName = "MemoryCardType", menuName = "ScriptableObjects/memoryCards")]
    public class NewCardScript : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public string Cardname;
        public Sprite ImageFront;
        public Sprite ImageBack;
        public NewSceneManager sceneController;
        private int _id;
        public int id
        {
            get { return _id; }

            set { _id = value; }
        }

        private void Start()
        {
            sceneController = GameObject.FindObjectOfType<NewSceneManager>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(eventData.pressPosition);
            //make sure this is a general scene controller
            sceneController.AfterClick(this.gameObject);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging");
        }
        private void Delete()
        {
            Destroy(gameObject);
        }
        public void Initialize()
        {
            

            ////hides the image of the card
            //Transform frontImage = transform.GetChild(1);
            //frontImage.gameObject.SetActive(false);

        }
    }
}
