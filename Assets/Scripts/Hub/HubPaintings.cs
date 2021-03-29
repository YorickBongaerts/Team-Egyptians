using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class HubPaintings : MonoBehaviour
{
    public string MinigameName;

    public void OnPaintingTap(InputAction.CallbackContext context)
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
