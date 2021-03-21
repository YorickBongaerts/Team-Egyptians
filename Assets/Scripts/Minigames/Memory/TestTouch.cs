using UnityEngine;

public class TestTouch : MonoBehaviour
{
    //A class to test the touch, should be implemented within the minigame logic

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

    public void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinates = cameraMain.ScreenToViewportPoint(screenCoordinates);
        worldCoordinates.z = 0;
        transform.position = worldCoordinates;
    }
}
