using MexiColeccion.Utils;
using System;
using UnityEngine;

namespace MexiColeccion.Minigames.Teotihuacan
{

    public class AccuracyChecker : MonoBehaviour
    {
        public GameOverManager GameOverManager;
        public Timer Timer;
        public Renderer PlayerPaintingQuad;
        public PaintingChooser ActualPainting;

        public int ScoreVictoryTreshhold;

        public int Score = 0;
        private int _totalPixels;

        private bool _needsToCount = true;

        // Update is called once per frame

        void Update()
        {
            if (Timer.remainingTime <= 0 && _needsToCount)
            {
               Score = CalculateScore();
                _needsToCount = false;

                if (Score > ScoreVictoryTreshhold)
                    GameOverManager.OnVictory();
                else
                    GameOverManager.OnDefeat();
            }
        }

        public int CalculateScore()
        {
            int score = 0;

            Texture2D firstTex = PlayerPaintingQuad.material.mainTexture as Texture2D;
            Texture2D secondTex = ActualPainting.CompareTexture;

            firstTex = ResizeTetxures(firstTex, secondTex.width, secondTex.height);

            Color[] firstPix = firstTex.GetPixels();
            Color[] secondPix = secondTex.GetPixels();

            if (firstPix.Length != secondPix.Length)
            {
                Debug.LogError("Textures are not the same size, must be same size");
            }
            else
            {
                _totalPixels = firstPix.Length;

                int correctPixels = 0;

                for (int i = 0; i < firstPix.Length; i++)
                {
                    correctPixels += ComparePixel(firstPix, secondPix, i);
                }

                score = correctPixels * 100 / _totalPixels;
                Debug.Log(correctPixels);
                Debug.Log("score: " + score + "%");
                Debug.Log(_totalPixels);
            }

            return score;
        }

        private Texture2D ResizeTetxures(Texture2D resizeTexture, int targetX, int targetY)
        {
            RenderTexture rt = new RenderTexture(targetX, targetY, 24);
            RenderTexture.active = rt;
            Graphics.Blit(resizeTexture, rt);
            Texture2D result = new Texture2D(targetX, targetY);
            result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
            result.Apply();
            return result;
        }

        private int ComparePixel(Color[] firstPix, Color[] secondPix, int i)
        {
            Vector3 firstVector = new Vector3(firstPix[i].r, firstPix[i].g, firstPix[i].b);

            Vector3 secondVector = new Vector3(secondPix[i].r, secondPix[i].g, secondPix[i].b);

            if (CalculateRGBValues(firstVector, secondVector,0.1f))
            {
                return 1;
            }
            else
                return 0;
        }

        private bool CalculateRGBValues(Vector3 firstVector, Vector3 secondVector, float margin)
        {
            float rValue = Mathf.Abs(firstVector.x - secondVector.x);
            float gValue = Mathf.Abs(firstVector.y - secondVector.y);
            float bValue = Mathf.Abs(firstVector.z - secondVector.z);

            if (rValue < margin && gValue < margin && bValue < margin)
                return true;
            else
                return false;
        }
    }
}


