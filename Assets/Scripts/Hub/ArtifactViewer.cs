using MexiColeccion.Collection;
using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using MexiColeccion.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColeccion.Hub
{
    public class ArtifactViewer : InputController
    {
        [SerializeField] private GameObject _pedestalPrefab = null;
        [SerializeField] private GameObject _container = null;
        [SerializeField] private MainHubUI _hubUI = null;
        [SerializeField] private PlayerBehaviour _playerScript = null;
        [Tooltip("The speed at which the user can browse through the artifacts.")]
        [SerializeField] private float _slideSpeed = 2f;
        [SerializeField] private float _distanceBetweenArtifacts = 3f;
        
        private List<GameObject> _artifacts = null;
        private Vector3 _destination = Vector3.zero, _origin = Vector3.zero;
        private float _startOffset = 1.54f;
        private int _index = 0;
        private bool _indexChanged = false;
        private bool _isOpen = false;

        public bool IsInteractedWith { get; private set; }

        private int Index
        {
            get => _index;
            set
            {
                GameObject artifact = _artifacts[Index];
                artifact.GetComponentInChildren<Artifact>().ToggleInteractivity(false);

                _index = Mathf.Clamp(value, 0, _artifacts.Count - 1);
                
                artifact = _artifacts[Index];
                float destination = artifact.transform.position.x + _startOffset;
                _destination = new Vector3(_origin.x + transform.position.x - destination, transform.position.y, transform.position.z);

                artifact.GetComponentInChildren<Artifact>().ToggleInteractivity(true);
                _indexChanged = true;
            }
        }

        private void Start()
        {
            _hubUI.ViewerTapped += ViewerTapped;
            _artifacts = new List<GameObject>();
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

        private void OnDestroy()
        {
            _hubUI.ViewerTapped -= ViewerTapped;
        }

        private bool IsApproximately(float a, float b, float threshold)
        {
            return ((a < b) ? (b - a) : (a - b)) <= threshold;
        }

        private void ViewerTapped(object sender, OnViewerTappedEventArgs e)
        {
            if (e.IsOpened)
            {
                RemoveInstantiatedArtifacts();
                SetupArtifacts(e.Minigame);
                //UpdateCollider();
                UpdatePosition(e.Minigame);
            }
            _isOpen = e.IsOpened;
        }

        private void UpdateCollider()
        {
            BoxCollider bc = GetComponent<BoxCollider>();
            bc.size = new Vector3(4f * _artifacts.Count, bc.size.y, bc.size.z);
            bc.center = new Vector3(_artifacts.Count, bc.center.y, bc.center.z);
        }

        private void RemoveInstantiatedArtifacts()
        {
            if (_artifacts == null || _artifacts.Count <= 0)
                return;

            for (int i = 0; i < _artifacts.Count; i++)
            {
                Destroy(_artifacts[i]);
            }
            _artifacts.Clear();
        }

        private void SetupArtifacts(Minigame currentMinigame)
        {
            List<ArtifactSO> artifactsToGenerate = CollectionDatabase.GetMinigameArtifacts(currentMinigame);

            // if there are no artifacts for this minigame, return
            if (artifactsToGenerate.Count <= 0)
                return;

            for (int i = 0; i < artifactsToGenerate.Count; i++)
            {
                GameObject pedestal = Instantiate(_pedestalPrefab
                    , new Vector3(_container.transform.position.x -_startOffset + (i * _distanceBetweenArtifacts)
                    , _pedestalPrefab.transform.localPosition.y + _container.transform.position.y - transform.position.y
                    , _container.transform.position.z)
                    , _pedestalPrefab.transform.rotation
                    , _container.transform);
                pedestal.GetComponentInChildren<Artifact>().ArtifactDataObject = artifactsToGenerate[i];
                _artifacts.Add(pedestal);
            }
        }

        internal void UpdatePosition(Minigame currentMinigame)
        {
            _origin = _playerScript.DestinationPosition;
            transform.position = new Vector3(_origin.x, transform.position.y, transform.position.z);

            if (CollectionDatabase.LastWonArtifact != null && CollectionDatabase.LastWonArtifact.Minigame == currentMinigame)
            {
                Index = CollectionDatabase.GetArtifactIndex(CollectionDatabase.LastWonArtifact);
            }
            else
            {
                Index = 0;
            }
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

            if (EventSystem.current.IsPointerOverGameObject(e.PointerInput.InputId) || !_isOpen)
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