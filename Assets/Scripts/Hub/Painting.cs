using MexiColeccion.Collection;
using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using MexiColeccion.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MexiColeccion.Hub
{
    public class Painting : InputController
    {
        [Tooltip("The Minigame that will be loaded when the user select this painting.")]
        [SerializeField] private Minigame _minigame;

        private Vector2 _inputPosition;
        private bool ShouldLoad = false;

        internal Minigame Minigame => _minigame;

        protected override void OnPressed(object sender, PointerEventArgs e)
        {
            base.OnPressed(sender, e);

            _inputPosition = e.PointerInput.Position;

            if (EventSystem.current.IsPointerOverGameObject(e.PointerInput.InputId))
                return;

            Ray ray = Camera.main.ScreenPointToRay(_inputPosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    ShouldLoad = true;
                }
            }
        }
        protected override void OnReleased(object sender, PointerEventArgs e)
        {
            base.OnReleased(sender, e);
            if (ShouldLoad)
            {
                ShouldLoad = false;
                LevelLoader.LoadNextLevel(CollectionDatabase.GetSceneName(Minigame), "CrossFade");
            }
        }
    }
}