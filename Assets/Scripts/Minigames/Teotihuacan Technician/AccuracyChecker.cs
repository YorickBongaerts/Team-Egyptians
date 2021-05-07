using MexiColeccion.Utils;
using System;
using UnityEngine;

namespace MexiColeccion.Minigames.Teotihuacan
{

    public class AccuracyChecker : MonoBehaviour
    {
        [SerializeField] private int _widthDepth;
        [SerializeField] private int _heigthDepth;
        public GameOverManager GameOverManager;
        public Timer Timer;
        public Painter PainterScript;
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
                    GameOverManager.OnVictory(Score);
                else
                    GameOverManager.OnDefeat(Score);
            }
        }

        public int CalculateScore()
        {
            PainterScript.UpdateTexture();

            int score = 0;

            Texture2D firstTex = PainterScript.TextureToCheck as Texture2D;
            Texture2D secondTex = ActualPainting.CompareTexture;

            firstTex = ResizeTetxures(firstTex, _widthDepth, _heigthDepth);
            secondTex = ResizeTetxures(secondTex, _widthDepth, _heigthDepth);

            Color[] PlayerPix = firstTex.GetPixels();
            Color[] ExamplePix = secondTex.GetPixels();

            if (PlayerPix.Length != ExamplePix.Length)
            {
                Debug.LogError("Textures are not the same size, must be same size");
            }
            else
            {
                _totalPixels = PlayerPix.Length;

                int correctPixels = 0;

                for (int i = 0; i < PlayerPix.Length; i++)
                {
                    correctPixels += ComparePixel(PlayerPix, ExamplePix, i);
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

        private int ComparePixel(Color[] PlayerPix, Color[] ExamplePix, int i)
        {
            Vector4 firstVector = new Vector4(PlayerPix[i].r, PlayerPix[i].g, PlayerPix[i].b, PlayerPix[i].a);

            Vector4 secondVector = new Vector4(ExamplePix[i].r, ExamplePix[i].g, ExamplePix[i].b, ExamplePix[i].a);

            if (CalculateRGBValues(firstVector, secondVector,0.1f))
            {
                return 1;
            }
            else
                return 0;
        }

        private bool CalculateRGBValues(Vector4 firstVector, Vector4 secondVector, float margin)
        {
            if(secondVector.w <0.5f) //0.5f is jst a random low enough value to check if it has alpha(meaning it shouldnt count this pixel)
            {
                _totalPixels--;
                Debug.Log("alpha");
                return false;
            }
            else
            {
                float rValue = Mathf.Abs(firstVector.x - secondVector.x);
                float gValue = Mathf.Abs(firstVector.y - secondVector.y);
                float bValue = Mathf.Abs(firstVector.z - secondVector.z);

                return (rValue < margin && gValue < margin && bValue < margin);
            }

        }
    }
}


