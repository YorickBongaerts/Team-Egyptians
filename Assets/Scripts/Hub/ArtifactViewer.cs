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
        private float _distanceToMove;
        private int _index;

        public bool IsInteractedWith { get; private set; }

        private int Index
        {
            get => _index;
            set
            {
                _index = Mathf.Clamp(value, 0, _artifacts.Length - 1);
                transform.position = new Vector3(_artifacts[Index].transform.position.x, transform.position.y, transform.position.z);
            }
        }

        public void UpdatePosition()
        {
            transform.position = new Vector3(_playerScript.DestinationPosition.x, transform.position.y, transform.position.z);
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
                    print("Interacting with viewer");
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

            if (e.PointerInput.Swipe.Direction.x > 0.5f)
            {
                print("Swiped left to right");
                Index += 1;
            }
            else if (e.PointerInput.Swipe.Direction.x < -0.5f)
            {
                print("Swiped right to left");
                Index -= 1;
            }
            IsInteractedWith = false;
        }
    }
}