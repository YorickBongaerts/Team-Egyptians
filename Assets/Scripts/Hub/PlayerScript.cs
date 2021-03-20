using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Collider _leftTrigger;
    [SerializeField]
    private Collider _rightTrigger;
    public bool _isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _leftTrigger)
        {
            gameObject.transform.position = _rightTrigger.gameObject.transform.position;

        }
        if (other == _rightTrigger)
        {
            gameObject.transform.position = _leftTrigger.gameObject.transform.position;
        }

    }
    public void GoToSide(Vector3 destinationPosition)
    {
        if (_isMoving)
        {
            Debug.Log("moved");
            Vector3 Position = Vector3.MoveTowards(gameObject.transform.position, destinationPosition, 100f * Time.deltaTime);
            //float xPosition = Mathf.Lerp(_playerCharacter.transform.position.x, _destinationPosition.x, 1f*Time.deltaTime);
            gameObject.transform.position = Position;
            if (gameObject.transform.position == destinationPosition)
            {
                _isMoving = false;
            }
        }
    }
}
