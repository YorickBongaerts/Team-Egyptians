using MexiColeccion.Input.Utilities;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Utils.Debug
{
    public class InputDebugger : MonoBehaviour
    {
        [SerializeField] private Text _info = null;
        [SerializeField] private Image _panel = null;
        [SerializeField] private bool _enableDebug;

        private void Start()
        {
            _panel.enabled = _enableDebug;
        }

        // Temporary, for visualizing input from new input system.
        internal void DebugInfo(PointerInput input)
        {
            if (!_enableDebug)
                return;
                
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("ID: {0}", input.InputId);
            builder.AppendLine();
            builder.AppendFormat("Position: {0}", input.Position);
            builder.AppendLine();
            builder.AppendLine();
            builder.AppendFormat("Start: {0}", input.StartTime);
            builder.AppendLine();
            builder.AppendFormat("End: {0}", input.EndTime);
            builder.AppendLine();

            if (input.Pressure.HasValue)
            {
                builder.AppendFormat("Pressure: {0}", input.Pressure);
                builder.AppendLine();
            }
            if (input.Radius.HasValue)
            {
                builder.AppendFormat("Radius: {0}", input.Radius);
                builder.AppendLine();
            }
            builder.AppendFormat("Swipe:");
            builder.AppendLine();
            builder.AppendFormat("      Start Position: {0}", input.Swipe.StartPosition);
            builder.AppendLine();
            builder.AppendFormat("      End Position: {0}", input.Swipe.EndPosition);
            builder.AppendLine();
            builder.AppendFormat("      Distance: {0}", input.Swipe.Distance);
            builder.AppendLine();
            builder.AppendFormat("      Direction: {0}", input.Swipe.Direction);
            builder.AppendLine();
            builder.AppendFormat("      Delta: {0}", input.Swipe.Delta);
            builder.AppendLine();

            _info.text = builder.ToString();
        }
    }
}