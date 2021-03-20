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
    private Vector3 _spaceBetweenObjects = new Vector3(400,0,0);
    private Vector3 _destinationPosition;
    [SerializeField]
    private GameObject _playerCharacter;
    private PlayerScript PlayerScript;

    void Update()
    {
        PlayerScript = _playerCharacter.GetComponent<PlayerScript>();
    }

    public void OnLeftButtonUpDown()
    {
        Debug.Log("TappedLeft");
        _tappedSide = -1;
        PlayerScript._isMoving = true;
        _destinationPosition = _playerCharacter.transform.position + _tappedSide * _spaceBetweenObjects;
        _playerCharacter.GetComponent<PlayerScript>().GoToSide(_destinationPosition);
    }
    public void OnRightButtonDown()
    {
        Debug.Log("TappedRight");
        _tappedSide = 1;
        PlayerScript._isMoving = true;
        _destinationPosition = _playerCharacter.transform.position + _tappedSide * _spaceBetweenObjects;
    }
    
    public void OnPaintingMemeoryUp()
    {
        Debug.Log("Now entering memory game");
        SceneManager.LoadScene("MiniGame-Memory");
    }

    public void OnPaintingTechnicianUp()
    {
        Debug.Log("Now entering technician game");
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
            Time.timeScale = 0;
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
            Time.timeScale = 1;
        }
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
   
}
