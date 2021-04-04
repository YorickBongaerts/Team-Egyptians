using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace MexiColleccion.Hub
{
    public class Painting : MonoBehaviour
    {
        /// <summary>
        /// This is the new version of the HubPaintings Script
        /// </summary>

        public string MinigameName;
        private Vector2 _inputPosition;

        public void OnTapPosition(InputAction.CallbackContext context)
        {
            TouchControl control = context.control.parent as TouchControl;
            _inputPosition = control.position.ReadValue();
            print(_inputPosition);
        }

        public void OnPaintingTap(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                Ray ray = Camera.main.ScreenPointToRay(_inputPosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.transform.gameObject == this.gameObject)
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
        }
    }
}