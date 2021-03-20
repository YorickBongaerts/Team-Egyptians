using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _optionsUI;

    [SerializeField]
    private List<GameObject> _activeUI;

    private bool _isInOptions = false;

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
            WorldEdge();
            if (_playerCharacter.transform.position == _destinationPosition)
            {
                _isMoving = false;
            }
        }
    }
    public void OnPaintingMemeoryUp()
    {
        Debug.Log("Now enetering pmemory game");
        SceneManager.LoadScene("MiniGame-Memory");
    }

    public void OnPaintingTechnicianUp()
    {
        Debug.Log("Now enetering technician game");
        SceneManager.LoadScene("MiniGame-Artist");
    }

    public void OnOptionsClick()
    {
        if(_isInOptions== false)
        {
            
            foreach (GameObject ui in _optionsUI)
            {
                ui.SetActive(true);
            }

            foreach (GameObject ui in _activeUI)
            {
                ui.SetActive(false);
            }
            _isInOptions = true;
        }
    }

    public void OnContinueClick()
    {
        if (_isInOptions == true)
        {
            foreach (GameObject ui in _optionsUI)
            {
                ui.SetActive(false);
            }

            foreach (GameObject ui in _activeUI)
            {
                ui.SetActive(true);
            }
            _isInOptions = false;
        }
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
    private void WorldEdge()
    {

    }
}
