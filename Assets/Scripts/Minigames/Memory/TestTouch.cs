using UnityEngine;

public class TestTouch : MonoBehaviour
{
    //A class to test the touch, should be implemented within the minigame logic
    //Tutorial used: https://youtu.be/ERAN5KBy2Gs

    private MemoryInputManager inputManager;
    private Camera cameraMain;

    private void Awake()
    {
        inputManager = MemoryInputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time) //this is unnecesary for our minigame, is to test if the touch works by moving an objecto to the mouse coordinates
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinates = cameraMain.ScreenToViewportPoint(screenCoordinates);
        worldCoordinates.z = 0;
        transform.position = worldCoordinates; 
    }
}
