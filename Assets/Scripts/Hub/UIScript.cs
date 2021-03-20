using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private int _tappedSide = 0;
    private Vector3 _spaceBetweenObjects = new Vector3(50,0,0);
    private Vector3 _destinationPosition;
    private bool _isMoving = false;
    [SerializeField]
    private GameObject _playerCharacter;
    void Update()
    {
        GoToSide();
    }

    public void OnLeftButtonUpDown()
    {
        Debug.Log("TappedLeft");
        _tappedSide = -1;
        _isMoving = true;
        _destinationPosition = _playerCharacter.transform.position + _tappedSide * _spaceBetweenObjects;
    }
    public void OnRightButtonDown()
    {
        Debug.Log("TappedRight");
        _tappedSide = 1;
        _isMoving = true;
        _destinationPosition = _playerCharacter.transform.position + _tappedSide * _spaceBetweenObjects;
    }
    private void GoToSide()
    {
        if (_isMoving)
        {
            Debug.Log("moved");
            Vector3 Position = Vector3.MoveTowards(_playerCharacter.transform.position, _destinationPosition, 20f * Time.deltaTime);
            //float xPosition = Mathf.Lerp(_playerCharacter.transform.position.x, _destinationPosition.x, 1f*Time.deltaTime);
            _playerCharacter.transform.position = Position;
            if (_playerCharacter.transform.position == _destinationPosition)
            {
                _isMoving = false;
            }
        }
    }
}
