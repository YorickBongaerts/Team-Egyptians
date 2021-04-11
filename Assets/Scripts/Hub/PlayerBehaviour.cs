using MexiColleccion.UI;
using System;
using System.Collections;
using UnityEngine;

namespace MexiColleccion.Hub
{
    /// <summary>
    /// This is the new version of the PlayerScript (deleted)
    /// </summary>
    public class PlayerBehaviour : MonoBehaviour
    {

        [SerializeField] private Collider _leftTrigger;
        [SerializeField] private Collider _rightTrigger;
        [SerializeField] private MainHubUI _hubUI;
        [SerializeField] private GameObject[] _paintings;

        private float _movementSpeed = 10f;
        private int _index = 0;
        private bool _isMoving = false;
        private bool _isDirectionLocked = false;

        public string LastMinigame = "Drawing";
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private Vector3 DestinationPosition
        {
            get
            {
                // move towards left trigger to warp
                if (_index < 0)
                {
                    return _leftTrigger.transform.position;
                }
                // move towards right trigger to warp
                if (_index >= _paintings.Length)
                {
                    return _rightTrigger.transform.position;
                }
                if (LastMinigame == "Minigame-Teotihuacan")
                {
                    _index = 1;
                }
                else if(LastMinigame == "Minigame-Memory")
                {
                    _index = 0;
                }
                return _paintings[_index].transform.GetChild(0).position;
            }
        }

        private void Start()
        {
            transform.position = DestinationPosition;
            _hubUI.ArrowTapped += ArrowTapped;
        }

        private void LateUpdate()
        {
            MoveToSide(DestinationPosition);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            _hubUI.ArrowTapped -= ArrowTapped;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == _leftTrigger)
            {
                WarpToAndTempDisableTrigger(_rightTrigger);
                _index = _paintings.Length - 1;
                return;
            }
            if (other == _rightTrigger)
            {
                WarpToAndTempDisableTrigger(_leftTrigger);
                _index = 0;
            }
        }

        private void WarpToAndTempDisableTrigger(Collider otherTrigger)
        {
            // warp to opposite side
            transform.position = otherTrigger.gameObject.transform.position;

            // temporarily disable this trigger
            otherTrigger.gameObject.SetActive(false);
            _isDirectionLocked = true;
            
            StartCoroutine(DelayTriggerActivation(otherTrigger));
        }

        private IEnumerator DelayTriggerActivation(Collider trigger)
        {
            yield return new WaitForSeconds(0.1f);
            
            if (trigger.gameObject.activeSelf == false)
            {
                trigger.gameObject.SetActive(true);
            }
            _isDirectionLocked = false;
        }

        private void ArrowTapped(object sender, OnArrowTappedEventArgs e)
        {
            if (_isDirectionLocked)
            {
                return;
            }
            
            _index += e.Direction;
            _isMoving = true;
        }

        private void MoveToSide(Vector3 destinationPosition)
        {
            if (_isMoving)
            {
                Debug.Log("moved");
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position
                    , destinationPosition, _movementSpeed * Time.deltaTime);

                if (gameObject.transform.position == destinationPosition)
                {
                    _isMoving = false;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, DestinationPosition);
        }
    }
}