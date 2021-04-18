using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MexiColleccion.Minigames.Teotihuacan
{
    public class PaintingChooser : MonoBehaviour
    {
        //make sure the display painting and their respective compare painting are in the same index in both lists.
        //each painting that gets displayed has a compare texture attached that is used to compare at the end of the game.
        [Tooltip("painting that will be displayed on the screen")]
        public List<Texture2D> DisplayTextures = new List<Texture2D>();
        [Tooltip("comparable painting that will be compared to at the end of the game")]
        public List<Texture2D> CompareTextures = new List<Texture2D>();

        public float DisplayTime;
        private bool _hasStoppedDisplaying;

        public Texture2D CompareTexture;
        // Start is called before the first frame update
        void Start()
        {
            if (DisplayTextures.Count != CompareTextures.Count)
                Debug.LogError("Missing textures in lists.");
            else
            {
                int r = Random.Range(0, DisplayTextures.Count);

                this.GetComponent<Renderer>().material.mainTexture = DisplayTextures[r];
                CompareTexture = CompareTextures[r];
            }
        }

        private void Update()
        {
            DisplayTime -= Time.deltaTime;
            if(DisplayTime<=0 && !_hasStoppedDisplaying)
            {
                this.transform.position += new Vector3(0, 0, 10);
                _hasStoppedDisplaying = true;
            }
        }
    }
}

