﻿using UnityEngine;
using UnityEngine.SceneManagement;
using MexiColleccion.Input;
using MexiColleccion.Input.Utilities;
using UnityEngine.EventSystems;
using UnityEditor;

namespace MexiColleccion.Hub
{
    /// <summary>
    /// This is the new version of the HubPaintings Script (deleted)
    /// </summary>
    internal class Painting : InputManager
    {
        [Tooltip("The scene that needs to be loaded when the user select this Minigame.")]
        [SerializeField] private SceneAsset _sceneToLoad;

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
                    SceneManager.LoadScene(_sceneToLoad.name);
                }
            }
        }
    }
}