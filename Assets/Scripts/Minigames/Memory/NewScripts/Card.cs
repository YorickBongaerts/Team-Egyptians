using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColeccion.Minigames.Memory
{
    //[CreateAssetMenu(fileName = "MemoryCardType", menuName = "ScriptableObjects/memoryCards")]
    public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        [SerializeField] private string _cardName;
        [SerializeField] private Sprite _imageShow;
        [SerializeField] private Sprite _imageHide;
        private SceneManager _sceneController; // TODO: is this used somewhere?
        private int _id;

        public Sprite ImageHide { get => _imageHide; set => _imageHide = value; }
        public Sprite ImageShow { get => _imageShow; set => _imageShow = value; }
        public int Id
        {
            get { return _id; }

            set { _id = value; }
        }

        private void Start()
        {
            _sceneController = FindObjectOfType<SceneManager>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            //Debug.Log(eventData.pressPosition);
            ////make sure this is a general scene controller
            //sceneController.AfterClick(this.gameObject);
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
