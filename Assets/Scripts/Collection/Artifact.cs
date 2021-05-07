using System;
using System.Collections;
using MexiColeccion.Collection;
using MexiColeccion.Hub;
using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using UnityEngine;

public class Artifact : InputController
{
    private ArtifactSO _artifactData; // reference that will be set by Artifact Viewer
    private float _rotationSpeed = 25f;

    private BoxCollider _collider = null;

    private bool _isCollected;
    private bool _isInteractable;

    internal int ArtifactIndex { get; set; }
    internal bool IsInteractedWith { get; private set; }
    private bool IsCollected
    {
        get => _isCollected;
        set
        {
            _isCollected = value;
            if (IsCollected)
            {
                //code if artifact is collected
                GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                //code if artifact is not collected
                Debug.Log("Not collected yet");
            }
        }
    }

    internal ArtifactSO ArtifactDataObject
    {
        get => _artifactData;
        set
        {
            _artifactData = value;
            if (value != null)
            {
                GetComponent<MeshFilter>().mesh = ArtifactDataObject.Mesh;
                Debug.Log(_artifactData.Name);
                IsCollected = PlayerPrefs.GetInt(_artifactData.Name) == 1; // 1 means it has been unlocked, 0 if it hasn't (standard is 0)
            }
        }
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
