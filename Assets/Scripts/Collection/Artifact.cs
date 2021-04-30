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

    [SerializeField] private Material _collectedMaterial; // code here has to change depending on implemetation relics
    [SerializeField] private MinigameType _typeOfMinigame;
    [SerializeField] private float _rotationSpeed = 25f;

    private BoxCollider _collider = null;

    private string _artifactName; 
    private int _artifactIndex;
    private bool _isCollected;
    private bool _isInteractable;

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

    public void ToggleInteractivity(bool setActive)
    {
        if (_collider == null)
        {
            _collider = transform.parent.GetComponent<BoxCollider>();
        }
        _collider.enabled = setActive;
        _isInteractable = setActive;
    }

    protected override void OnPressed(object sender, PointerEventArgs e)
    {
        base.OnPressed(sender, e);
        
        Ray ray = Camera.main.ScreenPointToRay(e.PointerInput.Position);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.gameObject == transform.parent.gameObject && _isInteractable)
            {
                IsInteractedWith = true;
            }
        }
    }

    protected override void OnDragged(object sender, PointerEventArgs e)
    {
        base.OnDragged(sender, e);

        if (IsInteractedWith)
        {
            RotateArtifact(e.PointerInput);
        }
    }

    protected override void OnReleased(object sender, PointerEventArgs e)
    {
        base.OnReleased(sender, e);

        IsInteractedWith = false;
    }

    private void RotateArtifact(PointerInput input)
    {
        if (input.Swipe.Direction.y > 0.8f || input.Swipe.Direction.y < -0.8f)
        {
#if UNITY_EDITOR
            float pitch = input.Swipe.Delta.y * _rotationSpeed * Time.deltaTime;
#else
            float pitch = input.Swipe.Delta.y/Screen.height * _rotationSpeed * Time.deltaTime;
#endif
            transform.Rotate(Vector3.right, pitch, Space.World);
        }
        if (input.Swipe.Direction.x > 0.8f || input.Swipe.Direction.x < -0.8f)
        {
#if UNITY_EDITOR
            float yaw = input.Swipe.Delta.x * _rotationSpeed * Time.deltaTime;
#else
            float yaw = input.Swipe.Delta.x/Screen.width * _rotationSpeed * Time.deltaTime;
#endif
            transform.Rotate(Vector3.up, -yaw, Space.World);
        }
    }
}
