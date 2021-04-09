using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MexiColleccion.Input.Utilities
{
    /// <summary>
    /// Simple object to contain information for drag inputs.
    /// </summary>
    public struct PointerInput
    {
        public bool Contact;

        /// <summary>
        /// ID of input type.
        /// </summary>
        public int InputId;

        /// <summary>
        /// Position of input.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Pressure of input.
        /// </summary>
        public float? Pressure;

        /// <summary>
        /// Radius of input.
        /// </summary>
        public Vector2? Radius;
    }

#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class PointerInputComposite : InputBindingComposite<PointerInput>
    {
        [InputControl(layout = "Button")]
        public int contact;

        [InputControl(layout = "Vector2")]
        public int position;

        [InputControl(layout = "Vector2")]
        public int radius;

        [InputControl(layout = "Axis")]
        public int pressure;

        [InputControl(layout = "Integer")]
        public int inputId;

        public override PointerInput ReadValue(ref InputBindingCompositeContext context)
        {
            var contact = context.ReadValueAsButton(this.contact);
            var pointerId = context.ReadValue<int>(inputId);
            var pressure = context.ReadValue<float>(this.pressure);
            var radius = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.radius);
            var position = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.position);

            return new PointerInput
            {
                Contact = contact,
                InputId = pointerId,
                Position = position,
                Pressure = pressure > 0 ? pressure : (float?)null,
                Radius = radius.sqrMagnitude > 0 ? radius : (Vector2?)null,
            };
        }

#if UNITY_EDITOR
        static PointerInputComposite()
        {
            Register();
        }

#endif

        [RuntimeInitializeOnLoadMethod]
        private static void Register()
        {
            InputSystem.RegisterBindingComposite<PointerInputComposite>();
        }
    }
}