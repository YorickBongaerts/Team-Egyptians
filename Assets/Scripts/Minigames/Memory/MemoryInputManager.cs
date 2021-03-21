using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class MemoryInputManager : Singleton<MemoryInputManager>
{
    private Controls controls;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;


    private void Awake()
    {
        controls = new Controls();   
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.MemoryGame.TouchPress.started += ctx => StartTouch(ctx);
        controls.MemoryGame.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + controls.MemoryGame.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null)
            OnStartTouch(controls.MemoryGame.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended " + controls.MemoryGame.TouchPosition.ReadValue<Vector2>());
        if (OnEndTouch != null)
            OnEndTouch(controls.MemoryGame.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }
}
