using System;
using System.Collections;
using MexiColeccion.Hub;
using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using UnityEngine;

public class Artifact : InputController
{
    public enum MinigameType
    {
        memory,
        painter
    }

    public Material _collectedMaterial; // code here has to change depending on implemetation relics
    public MinigameType _typeOfMinigame;
    private bool _isCollected;
    private int _artifactIndex;
    private float _rotationSpeed = 20f;
    private string _artifactName; 

    internal ArtifactViewer ArtifactViewer;

    internal bool IsInteractedWith { get; private set; }
    private bool IsCollected
    {
        get => _isCollected;
        set
        {
            _isCollected = value;
            if (IsCollected)
            {
                GetComponent<Renderer>().material = _collectedMaterial;
            }
            else
            {
                Debug.Log("Not collected yet");
            }
        }
    }

    private void Start()
    {
        _artifactName = GetCorrectArtifactNameFromDataBase();
        Debug.Log(_artifactName);
        IsCollected = PlayerPrefs.GetInt(_artifactName) == 1; // 1 means it has been unlocked, 0 if it hasn't (standard is 0)
    }

    private string GetCorrectArtifactNameFromDataBase()
    {
        string artifactName = "default";

        if (_typeOfMinigame == MinigameType.memory)
            artifactName = CollectionDataBase.MemoryArtifacts[_artifactIndex];

        else if (_typeOfMinigame == MinigameType.painter)
            artifactName = CollectionDataBase.PainterArtifacts[_artifactIndex];

        return artifactName;
    }

    protected override void OnPressed(object sender, PointerEventArgs e)
    {
        base.OnPressed(sender, e);
        
        Ray ray = Camera.main.ScreenPointToRay(e.PointerInput.Position);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.gameObject == transform.parent.gameObject)
            {
                IsInteractedWith = true;
                print("Interacting with artifact");
            }
        }
    }

    protected override void OnDragged(object sender, PointerEventArgs e)
    {
        base.OnDragged(sender, e);

        if (IsInteractedWith)
        {
            RotateArtifact(e.PointerInput);
            print("Rotating artifact");
        }
    }

    protected override void OnReleased(object sender, PointerEventArgs e)
    {
        base.OnReleased(sender, e);

        IsInteractedWith = false;
        print("Stopped interacting with artifact");
    }

    private void RotateArtifact(PointerInput input)
    {
        if (input.Swipe.Direction.y > 0.5f || input.Swipe.Direction.y < -0.5f)
        {
            float rotX = input.Swipe.Delta.y * _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right, rotX);
        }
        if (input.Swipe.Direction.x > 0.5f || input.Swipe.Direction.x < -0.5f)
        {
            float rotY = input.Swipe.Delta.x * _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, -rotY);
        }
    }

    // private void IsNotCollected()
    // {
    //     Debug.Log("Not collected yet");
    // }

    //private void IsCollected()
    //{
    //    this.GetComponent<Renderer>().material = CollectedMaterial;
    //}

}
