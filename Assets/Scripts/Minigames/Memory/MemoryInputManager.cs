using MexiColleccion.Input;
using MexiColleccion.Input.Utilities;
using UnityEngine;

namespace MexiColleccion.Minigames.Memory
{
    public class MemoryInputManager : InputManager
    {
        protected override void OnPressed(object sender, PointerEventArgs e)
        {
            base.OnPressed(sender, e);

            Debug.Log($"Touch started at {e.PointerInput.Position} on {e.Context.time}");
        }

        protected override void OnReleased(object sender, PointerEventArgs e)
        {
            base.OnReleased(sender, e);

            Debug.Log($"Touch ended at {e.PointerInput.Position} on {e.Context.time}");
        }
    }
}