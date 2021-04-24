using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MexiColeccion.Input.Utilities
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
        /// Position of the touch input on the current frame.
        /// </summary>
        internal Vector2 Position;

        /// <summary>
        /// Position where the touch input started. Different from <see cref="Swipe.StartPosition"/>.
        /// </summary>
        internal Vector2 StartPosition;

        /// <summary>
        /// Position where the input was on the last callback.
        /// </summary>
        internal Vector2 PreviousPosition;

        /// <summary>
        /// Position where the input ended.
        /// </summary>
        internal Vector2 EndPosition;

        /// <summary>
        /// Distance the finger traveled since tha last frame, in screen units.
        /// </summary>
        internal Vector2 Delta;

        /// <summary>
        /// Swipe object that contains information like distance and direction.
        /// </summary>
        internal Swipe Swipe;

        /// <summary>
        /// The time this input started.
        /// </summary>
        internal double StartTime;

        /// <summary>
        /// The time this input ended.
        /// </summary>
        internal double EndTime;

        /// <summary>
        /// The time this input ended.
        /// </summary>
        internal double Duration;

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
        public int contact;

        [InputControl(layout = "Vector2")]
        public int position;

        [InputControl(layout = "Vector2")]
        public int radius;

        [InputControl(layout = "Vector2")]
        public int delta;

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
            var delta = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.delta);

            return new PointerInput
            {
                Contact = contact,
                InputId = pointerId,
                StartPosition = position,
                Position = position,
                Pressure = pressure > 0 ? pressure : (float?)null,
                Radius = radius.sqrMagnitude > 0 ? radius : (Vector2?)null,
                Delta = delta
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

    internal struct Swipe
    {
        /// <summary>
        /// ID of input that performed this swipe.
        /// </summary>
        internal readonly int InputId;

        /// <summary>
        /// Position where the input started on screen.
        /// </summary>
        internal Vector2 StartPosition;

        /// <summary>
        /// Position where the input was on the last callback.
        /// </summary>
        internal Vector2 PreviousPosition;

        /// <summary>
        /// Position where the input ended.
        /// </summary>
        internal Vector2 EndPosition;

        /// <summary>
        /// Distance the finger traveled during the swipe, in screen units.
        /// </summary>
        internal float Distance => (EndPosition - StartPosition).magnitude;

        /// <summary>
        /// Distance the finger traveled since tha last frame, in screen units.
        /// </summary>
        internal Vector2 Delta;

        /// <summary>
        /// Duration of the swipe in seconds.
        /// </summary>
        internal double SwipeDuration;

        internal Vector2 AccumulatedNormalized;

        /// <summary>
        /// Direction of the swipe.
        /// </summary>
        internal Vector2 Direction => (EndPosition - StartPosition).normalized;

        internal Swipe(PointerInput input)
        {
            InputId = input.InputId;
            StartPosition = input.StartPosition;
            PreviousPosition = input.PreviousPosition;
            EndPosition = input.EndPosition;
            Delta = input.Delta;
            SwipeDuration = input.Duration;
            AccumulatedNormalized = Vector2.zero;
        }
    }
}