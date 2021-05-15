using MexiColeccion.UI;
using UnityEngine;

namespace MexiColeccion.Hub
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject[] _paintings;
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Collider _leftTrigger;
        [SerializeField] private Collider _rightTrigger;
        [SerializeField] private MainHubUI _hubUI;
        [SerializeField] private float _movementSpeed = 10f;
        [SerializeField] private float _idleAnimationChangeInterval = 10f;

        private static int _index = 0;

        private GameObject _artifactsButton = null;
        private Quaternion _playerStartRotation;
        private float _idleTime = 0f;
        private int _direction = 0;

        internal Vector3 DestinationPosition
        {
            get
            {
                // move towards left trigger to warp
                if (_index < 0)
                {
                    return new Vector3(_leftTrigger.transform.position.x, transform.position.y, transform.position.z);
                }
                // move towards right trigger to warp
                if (_index >= _paintings.Length)
                {
                    return new Vector3(_rightTrigger.transform.position.x, transform.position.y, transform.position.z);
                }
                return new Vector3(_paintings[_index].transform.GetChild(0).position.x, transform.position.y, transform.position.z);
            }
        }

        internal Painting CurrentPainting => _paintings[_index].GetComponentInChildren<Painting>();

        private void Start()
        {
            transform.position = DestinationPosition;
            _playerStartRotation = _playerAnimator.transform.rotation;
            _hubUI.ArrowTapped += ArrowTapped;
        }

        private void Update()
        {
            _idleTime += Time.deltaTime;

            if (_idleTime >= _idleAnimationChangeInterval)
            {
                _playerAnimator.SetInteger("IdleRandom", Random.Range(0, 6));
                _idleTime = 0f;
            }
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
            if (other == _leftTrigger && _direction < 0)
            {
                WarpToTrigger(_rightTrigger);
                _index = _paintings.Length - 1;
                return;
            }
            if (other == _rightTrigger && _direction > 0)
            {
                WarpToTrigger(_leftTrigger);
                _index = 0;
            }
        }

        private void WarpToTrigger(Collider otherTrigger)
        {
            // warp to opposite side
            transform.position = new Vector3(otherTrigger.gameObject.transform.position.x, transform.position.y, transform.position.z);
        }

        private void ArrowTapped(object sender, OnArrowTappedEventArgs e)
        {
            if (_direction != 0)
            {
                return;
            }

            _direction = e.Direction;
            _index += _direction;
            _playerAnimator.SetInteger("Direction", _direction);
            _playerAnimator.applyRootMotion = false;
            _playerAnimator.transform.LookAt(DestinationPosition, Vector3.up);

            if (_artifactsButton == null)
            {
                _artifactsButton = e.ArtifactsButton;
            }
        }

        private void MoveToSide(Vector3 destinationPosition)
        {
            if (_direction != 0)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position
                    , destinationPosition, _movementSpeed * Time.deltaTime);

                if (gameObject.transform.position == destinationPosition)
                {
                    _direction = 0;
                    _playerAnimator.SetInteger("Direction", _direction);
                    _playerAnimator.transform.rotation = _playerStartRotation;
                    _playerAnimator.applyRootMotion = true;

                    if (_artifactsButton != null)
                    {
                        _artifactsButton.SetActive(true);
                    }
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, DestinationPosition);
        }
#endif
    }
}