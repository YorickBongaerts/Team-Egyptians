using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColeccion.Hub
{
    public class ArtifactViewer : InputController
    {
        [SerializeField] private GameObject[] _artifacts; // these will be loaded from the save file
        [SerializeField] private PlayerBehaviour _playerScript;
        [Tooltip("The speed at which the user can browse through the artifacts.")]
        [SerializeField] private float _slideSpeed = 2f;
        
        private Vector3 _destination, _origin;
        private float _startOffset;
        private int _index;
        private bool _indexChanged;

        public bool IsInteractedWith { get; private set; }

        private int Index
        {
            get => _index;
            set
            {
                _index = Mathf.Clamp(value, 0, _artifacts.Length - 1);

                float destination = _artifacts[Index].transform.position.x + _startOffset;
                _destination = new Vector3(_origin.x + transform.position.x - destination, transform.position.y, transform.position.z);
                _indexChanged = true;

                //Vector3 previousVisitedPosition = _artifacts[Index].transform.position;
                //_index = Mathf.Clamp(value, 0, _artifacts.Length - 1);
                //float distanceToMove = _artifacts[Index].transform.position.x - previousVisitedPosition.x;
                //_destination = new Vector3(transform.position.x - distanceToMove, transform.position.y, transform.position.z);
                //_indexChanged = true;
            }
        }

        private void Start()
        {
            _startOffset = transform.position.x - _artifacts[Index].transform.position.x;
        }

        private void Update()
        {
            if (_indexChanged)
            {
                transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * _slideSpeed);
                if (IsApproximately(transform.position.x, _destination.x, 0.01f))
                {
                    transform.position = _destination;
                    _indexChanged = false;
                }
            }
        }

        private bool IsApproximately(float a, float b, float threshold)
        {
            return ((a < b) ? (b - a) : (a - b)) <= threshold;
        }

        internal void UpdatePosition()
        {
            _origin = _playerScript.DestinationPosition;
            transform.position = new Vector3(_origin.x, transform.position.y, transform.position.z);
            Index = 0;
        }

        protected override void OnPressed(object sender, PointerEventArgs e)
        {
            base.OnPressed(sender, e);

            Ray ray = Camera.main.ScreenPointToRay(e.PointerInput.Position);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    IsInteractedWith = true;
                }
            }
        }

        protected override void OnReleased(object sender, PointerEventArgs e)
        {
            base.OnReleased(sender, e);

            if (EventSystem.current.IsPointerOverGameObject(e.PointerInput.InputId))
            {
                Debug.Log("Pointer over UI.");
                return;
            }

            if (_artifacts[Index].GetComponentInChildren<Artifact>().IsInteractedWith || !IsInteractedWith)
                return;

            if (e.PointerInput.Swipe.Direction.x > 0.8f)
            {
                print("Swiped left to right");
                Index -= 1;
            }
            else if (e.PointerInput.Swipe.Direction.x < -0.8f)
            {
                print("Swiped right to left");
                Index += 1;
            }
            IsInteractedWith = false;
        }
    }
}