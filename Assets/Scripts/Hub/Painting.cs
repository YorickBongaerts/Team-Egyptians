using UnityEngine;
using UnityEngine.SceneManagement;
using MexiColleccion.Input;
using MexiColleccion.Input.Utilities;

namespace MexiColleccion.Hub
{
    /// <summary>
    /// This is the new version of the HubPaintings Script (deleted)
    /// </summary>
    internal class Painting : InputManager
    {
        [SerializeField] private string _minigameName;
        private Vector2 _inputPosition;

        protected override void OnPressed(object sender, PointerEventArgs e)
        {
            base.OnPressed(sender, e);

            _inputPosition = e.PointerInput.Position;

            Ray ray = Camera.main.ScreenPointToRay(_inputPosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    if (_minigameName == "Painter")
                    {
                        SceneManager.LoadScene("Minigame-InputTest"); // TODO: change this to the correct scene
                    }

                    if (_minigameName == "Memory")
                    {
                        SceneManager.LoadScene("Minigame-Memory");
                    }
                }
            }
        }

        //public void OnTapPosition(InputAction.CallbackContext context)
        //{
        //    TouchControl control = context.control.parent as TouchControl;
        //    _inputPosition = control.position.ReadValue();
        //    print(_inputPosition);
        //}

        //public void OnPaintingTap(InputAction.CallbackContext context)
        //{
        //    if (context.ReadValueAsButton())
        //    {
        //        Ray ray = Camera.main.ScreenPointToRay(_inputPosition);
        //        if (Physics.Raycast(ray, out var hit))
        //        {
        //            if (hit.transform.gameObject == this.gameObject)
        //            {
        //                if (MinigameName == "Painter")
        //                {
        //                    SceneManager.LoadScene("Painter");
        //                }

        //                if (MinigameName == "Memory")
        //                {
        //                    SceneManager.LoadScene("Minigame-Memory");
        //                }
        //            }
        //        }
        //    }
        //}
    }
}