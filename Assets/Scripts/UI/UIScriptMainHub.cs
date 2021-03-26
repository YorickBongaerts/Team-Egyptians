using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScriptMainHub : UIScript
{

    private int _tappedSide = 0;
    private Vector3 _spaceBetweenObjects = new Vector3(400, 0, 0);
    private Vector3 _destinationPosition;
    [SerializeField]
    private GameObject _playerCharacter;
    private PlayerScript PlayerScript;
    
    private void Start()
    {
        PlayerScript = _playerCharacter.GetComponent<PlayerScript>();
    }
    void FixedUpdate()
    {
        if (PlayerScript._isMoving)
        {
            PlayerScript.GoToSide(_destinationPosition, _tappedSide);
        }
    }
    
    public void OnLeftButtonUpDown()
    {
        Debug.Log("TappedLeft");
        _tappedSide = -1;
        PlayerScript._isMoving = true;
        _destinationPosition = _playerCharacter.transform.position + _tappedSide * _spaceBetweenObjects;
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
        SceneManager.LoadScene("Painter - Erik");
    }

    public void OnRestartUp()
    {
        Debug.Log("Restarting Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

}
