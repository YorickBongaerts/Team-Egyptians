using MexiColeccion.Input;
using MexiColeccion.Input.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace MexiColeccion.Hub
{
    /// <summary>
    /// This is the new version of the HubPaintings Script (deleted)
    /// </summary>
    internal class Painting : InputController
    {
        [Tooltip("The scene that needs to be loaded when the user select this Minigame.")]
        //[SerializeField] private SceneAsset _sceneToLoad;
        // This only works in the Editor. I still need to find a way to use a reference field 
        // (auto update) instead of a string (manual update) that also works for a build. - Erik
        [SerializeField] private string _sceneToLoadName;

        private Vector2 _inputPosition;

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
                    SceneManager.LoadScene(_sceneToLoadName);
                }
            }
        }
    }
}