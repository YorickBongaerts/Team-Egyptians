using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames.Teotihuacan
{
    public class PaintingChooser : MonoBehaviour
    {
        //make sure the display painting and their respective compare painting are in the same index in both lists.
        //each painting that gets displayed has a compare texture attached that is used to compare at the end of the game.
        [Tooltip("painting that will be displayed on the screen as the example")]
        [SerializeField] private List<Texture2D> _displayTextures = new List<Texture2D>();
        [Tooltip("comparable painting that will be compared to at the end of the game")]
        [SerializeField] private List<Texture2D> _compareTextures = new List<Texture2D>();
        [Tooltip("Painting outline that will be displayed during the game")]
        [SerializeField] private List<Material> _outlineMaterials = new List<Material>();
        [Tooltip("Paintings displayed when players presses a button to show painting again")]
        [SerializeField] private List<Texture2D> _helpTextures = new List<Texture2D>();
        [SerializeField] private Image _displayIcon;
        [SerializeField] private Sprite _display, _hide;
        [SerializeField] private Renderer _outlineQuad;
        [SerializeField] private float _displayTime;

        private int _r;
        private bool _hasStoppedDisplaying;
        
        internal Texture2D CompareTexture;
        
        private void Start()
        {
            if (_displayTextures.Count != _compareTextures.Count
                || _outlineMaterials.Count != _displayTextures.Count
                || _outlineMaterials.Count != _compareTextures.Count)
            {
                Debug.LogError("Missing textures in lists.");
            }
            else
            {
                _r = Random.Range(0, _displayTextures.Count);

                this.GetComponent<Renderer>().material.mainTexture = _displayTextures[_r];
                CompareTexture = _compareTextures[_r];
                _outlineQuad.material = _outlineMaterials[_r];
            }

            _displayIcon.sprite = _hide;
        }

        private void Update()
        {
            _displayTime -= Time.deltaTime;
            if (_displayTime <= 0 && !_hasStoppedDisplaying)
            {
                this.GetComponent<Renderer>().material.mainTexture = _helpTextures[_r];
                this.transform.position += new Vector3(0, 0, 10); //gets moves back and forward whenever player presses the button to show the painting they are copying
                _hasStoppedDisplaying = true;
                _displayIcon.sprite = _display;
            }
        }
    }
}

