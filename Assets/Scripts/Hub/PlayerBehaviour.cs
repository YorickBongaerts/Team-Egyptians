using MexiColeccion.UI;
using System.Collections;
using UnityEngine;

namespace MexiColeccion.Hub
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

        private GameObject _artifactsButton = null;
        private float _movementSpeed = 10f;
        private static int _index = 0;
        private bool _isMoving = false;
        private bool _isDirectionLocked = false;

        internal Vector3 DestinationPosition
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

            if (_artifactsButton == null)
            {
                _artifactsButton = e.ArtifactsButton;
            }
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
                    _artifactsButton?.SetActive(true);
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