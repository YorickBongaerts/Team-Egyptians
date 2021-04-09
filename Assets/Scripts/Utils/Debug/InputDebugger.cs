using MexiColleccion.Input.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColleccion.Utils.Debug
{
    public class InputDebugger : MonoBehaviour
    {
        [SerializeField] private Text _info = null;

        // Temporary, for visualizing input from new input system.
        internal void DebugInfo(PointerInput input)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("ID: {0}", input.InputId);
            builder.AppendLine();
            builder.AppendFormat("Position: {0}", input.Position);

            if (input.Pressure.HasValue)
            {
                builder.AppendLine();
                builder.AppendFormat("Pressure: {0}", input.Pressure);
            }
            if (input.Radius.HasValue)
            {
                builder.AppendLine();
                builder.AppendFormat("Radius: {0}", input.Radius);
                builder.AppendLine();
            }

            _info.text = builder.ToString();
        }
    }
}