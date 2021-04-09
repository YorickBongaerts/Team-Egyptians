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
    internal struct PointerInput
    {
        internal bool Contact;

        /// <summary>
        /// ID of input type.
        /// </summary>
        internal int InputId;

        /// <summary>
        /// Position of input.
        /// </summary>
        internal Vector2 Position;

        /// <summary>
        /// Pressure of input.
        /// </summary>
        internal float? Pressure;

        /// <summary>
        /// Radius of input.
        /// </summary>
        internal Vector2? Radius;
    }

#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    internal class PointerInputComposite : InputBindingComposite<PointerInput>
    {
        [InputControl(layout = "Button")]
        internal int contact;

        [InputControl(layout = "Vector2")]
        internal int position;

        [InputControl(layout = "Vector2")]
        internal int radius;

        [InputControl(layout = "Axis")]
        internal int pressure;

        [InputControl(layout = "Integer")]
        internal int inputId;

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