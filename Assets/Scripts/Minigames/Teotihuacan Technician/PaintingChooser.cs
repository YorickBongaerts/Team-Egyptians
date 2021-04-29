using System.Collections.Generic;
using UnityEngine;

namespace MexiColeccion.Minigames.Teotihuacan
{
    public class PaintingChooser : MonoBehaviour
    {
        //make sure the display painting and their respective compare painting are in the same index in both lists.
        //each painting that gets displayed has a compare texture attached that is used to compare at the end of the game.
        [Tooltip("painting that will be displayed on the screen as the example")]
        public List<Texture2D> DisplayTextures = new List<Texture2D>();
        [Tooltip("comparable painting that will be compared to at the end of the game")]
        public List<Texture2D> CompareTextures = new List<Texture2D>();
        [Tooltip("Painting outline that will be displayed during the game")]
        public List<Texture2D> OverlayTextures = new List<Texture2D>();

        public float DisplayTime;
        private bool _hasStoppedDisplaying;

        public Texture2D CompareTexture;

        private int _r;
        // Start is called before the first frame update
        void Start()
        {
            if (DisplayTextures.Count != CompareTextures.Count || OverlayTextures.Count != DisplayTextures.Count || OverlayTextures.Count != CompareTextures.Count)
                Debug.LogError("Missing textures in lists.");
            else
            {
                _r = Random.Range(0, DisplayTextures.Count);

                this.GetComponent<Renderer>().material.mainTexture = DisplayTextures[_r];
                CompareTexture = CompareTextures[_r];
            }
        }

        private void Update()
        {
            DisplayTime -= Time.deltaTime;
            if (DisplayTime <= 0 && !_hasStoppedDisplaying)
            {
                //this.GetComponent<Renderer>().material.mainTexture = OverlayTextures[_r]; dit werk ni, geen idee waarom ni (lijn 43 stond in commentaar when i tried)
                this.transform.position += new Vector3(0, 0, 10);
                _hasStoppedDisplaying = true;
            }
        }
    }
}

