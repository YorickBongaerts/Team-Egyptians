using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class HubPaintings : MonoBehaviour
{
    public string MinigameName;
    public Camera camera;

    public void OnPaintingTap(InputAction.CallbackContext context)
    {
        Ray ray = camera.ScreenPointToRay(context.ReadValue<Vector3>());
        if(Physics.Raycast(ray, out var hit))
        {
            if( hit.transform.gameObject == this.gameObject)
            {
                if (MinigameName == "Painter")
                {
                    SceneManager.LoadScene("Painter");
                }
    
                if (MinigameName == "Memory")
                {
                    SceneManager.LoadScene("Minigame-Memory");
                }
            }
    
        }
    
    }

    //private void OnMouseDown()
    //{
    //    if (MinigameName == "Painter")
    //    {
    //        SceneManager.LoadScene("Painter");
    //    }
    //
    //    if (MinigameName == "Memory")
    //    {
    //        SceneManager.LoadScene("Minigame-Memory");
    //    }
    //}



}
