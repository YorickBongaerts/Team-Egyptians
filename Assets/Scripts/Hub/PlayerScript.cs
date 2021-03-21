using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Collider _leftTrigger;
    [SerializeField]
    private Collider _rightTrigger;
    public bool _isMoving = false;
    private Vector3 _destinationPosition;
    private Vector3 _destinationDistanceAfterTP = new Vector3(350, 0, 0);
    private bool _hasPositionChangedAfterTP = true;
    private bool isAssigned;
    private Collider _nonHitTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other == _leftTrigger)
        {
            gameObject.transform.position = _rightTrigger.gameObject.transform.position - new Vector3(50, 0, 0);
            _hasPositionChangedAfterTP = false;
            isAssigned = false;
            _nonHitTrigger = _rightTrigger;
        }
        if (other == _rightTrigger)
        {
            gameObject.transform.position = _leftTrigger.gameObject.transform.position + new Vector3(50, 0, 0);
            _hasPositionChangedAfterTP = false;
            isAssigned = false;
            _nonHitTrigger = _leftTrigger;
        }

    }
    public void GoToSide(Vector3 destinationPosition, int tappedSide)
    {
        if (!isAssigned)
        {
            _destinationPosition = destinationPosition;
            isAssigned = true;
        }
        if (_isMoving)
        {
            Debug.Log("moved");
            Vector3 Position = Vector3.MoveTowards(gameObject.transform.position, _destinationPosition, 100f * Time.fixedDeltaTime);
            //float xPosition = Mathf.Lerp(_playerCharacter.transform.position.x, _destinationPosition.x, 1f*Time.deltaTime);
            gameObject.transform.position = Position;
            if (gameObject.transform.position == _destinationPosition)
            {
                _isMoving = false;
                isAssigned = false;
            }
        }
        if (!_hasPositionChangedAfterTP)
        {
            _destinationPosition = _nonHitTrigger.gameObject.transform.position + _destinationDistanceAfterTP * tappedSide;
            _hasPositionChangedAfterTP = true;
        }
    }
}
