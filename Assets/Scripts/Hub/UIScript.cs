using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionsUI;

    [SerializeField]
    private GameObject _activeUI;

    private bool _isInOptions = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeftButtonUp()
    {
        Debug.Log("tapped");
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
            _optionsUI.SetActive(true);
            _activeUI.SetActive(false);
            _isInOptions = true;
        }
    }

    public void OnContinueClick()
    {
        if (_isInOptions == true)
        {
            _optionsUI.SetActive(false);
            _activeUI.SetActive(true);
            _isInOptions = false;
        }
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
}
