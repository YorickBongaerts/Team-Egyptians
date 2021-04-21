using MexiColleccion.Utils;
using UnityEngine;

namespace MexiColleccion.Minigames.Teotihuacan
{

    public class AccuracyChecker : MonoBehaviour
    {
        public GameOverManager GameOverManager;
        public Timer Timer;
        public Renderer PlayerPaintingQuad;
        public PaintingChooser ActualPainting;

        public int ScoreVictoryTreshhold;

        public int CorrectPixels = 0;
        public int Score = 0;
        public int TotalPixels;

        private bool _needsToCount = true;
        // Update is called once per frame
        void Update()
        {
            if (Timer.remainingTime <= 0 && _needsToCount)
            {
                Texture2D firstTex = PlayerPaintingQuad.material.mainTexture as Texture2D;
                Texture2D secondTex = ActualPainting.CompareTexture;

                CompareTextures(firstTex, secondTex); // original texture sizes must be (743,353), because original player painted texture is this size.
                                                      // (depends on screen size??)
                _needsToCount = false;
            }
        }

        private void CompareTextures(Texture2D firstTex, Texture2D secondTex)
        {
            //Texture2D firstTex = playerTexture.material.mainTexture as Texture2D;
            //Texture2D secondTex = actualTexture.material.mainTexture as Texture2D;
            Color[] firstPix = firstTex.GetPixels();
            Color[] secondPix = secondTex.GetPixels();

            Debug.Log(firstTex.width);
            Debug.Log(firstTex.height);
            Debug.Log(secondTex.width);
            Debug.Log(secondTex.height);

            if (firstPix.Length != secondPix.Length)
            {
                Debug.LogError("Textures are not the same size, must be same size");
            }
            else
            {
                TotalPixels = firstPix.Length;

                for (int i = 0; i < firstPix.Length; i++)
                {
                    ComparePixel(firstPix, secondPix, i);
                }

                Score = CorrectPixels * 100 / TotalPixels;
                Debug.Log("score: " + Score + "%");

                // if (Score > ScoreVictoryTreshhold)
                //     GameOverManager.OnVictory();
                // else
                //     GameOverManager.OnDefeat();
            }
        }

        private void ComparePixel(Color[] firstPix, Color[] secondPix, int i)
        {
            Vector3 firstVector = new Vector3(firstPix[i].r, firstPix[i].g, firstPix[i].b);

            Vector3 secondVector = new Vector3(secondPix[i].r, secondPix[i].g, secondPix[i].b);

            if (firstVector == secondVector) // not finished yet
            {
                CorrectPixels++;
            }
        }
    }
}


