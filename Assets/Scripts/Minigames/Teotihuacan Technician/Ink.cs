using UnityEngine;
using UnityEngine.UI;

namespace MexiColleccion.Minigames.Teotihuacan
{
    public class Ink : MonoBehaviour
    {
        [Tooltip("How much ink the container can hold. Measured in ml.")]
        [SerializeField] private float _maxInkCapacity = 100f;

        internal float InkRemaining { get; set; }
        internal Color InkColor { get; private set; }

        private void Start()
        {
            InkColor = GetComponent<Image>().color;
            InkRemaining = _maxInkCapacity;
        }
    }
}
