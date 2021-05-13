using MexiColeccion.Utils;
using System.Collections;
using UnityEngine;

namespace MexiColeccion.Minigames.Teotihuacan
{
    public class AccuracyChecker : MonoBehaviour
    {
        [SerializeField] private int _widthDepth;
        [SerializeField] private int _heigthDepth;
        [SerializeField] private GameOverManager _gameOverManager;
        [SerializeField] private Timer _timer;
        [SerializeField] private PaintingChooser _actualPainting;
        [SerializeField] private int ScoreVictoryTreshhold;
        
        private Painter _painterScript;
        private int _score = 0;
        private int _totalPixels;
        private bool _needsToCount = true;

        internal int CurrentScore
        {
            get
            {
                // only recalculate the score if there were changes to the paint, else simply return the latest saved score
                if (_painterScript.HasPaintChanged)
                    CalculateScore();

                return _score;
            }
        }

        private void Start()
        {
            _painterScript = GetComponent<Painter>();
        }

        private void Update()
        {
            if (_timer.RemainingTime <= 0 && _needsToCount)
            {
                _needsToCount = false;

                OnEndGame();
            }
        }

        internal void OnEndGame()
        {
            StartCoroutine(DetermineWinOrLose());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator DetermineWinOrLose()
        {
            yield return new WaitForSeconds(Time.deltaTime * 2);

            if (CurrentScore > ScoreVictoryTreshhold)
                _gameOverManager.OnVictory(CurrentScore);
            else
                _gameOverManager.OnDefeat(CurrentScore);
        }

        internal void CalculateScore()
        {
            _painterScript.CanUpdate = true;

            StartCoroutine(WaitForTextureUpdate());
        }

        private IEnumerator WaitForTextureUpdate()
        {
            yield return new WaitForEndOfFrame();

            Texture2D firstTex = _painterScript.TextureToCheck;
            Texture2D secondTex = _actualPainting.CompareTexture;

            firstTex = ResizeTextures(firstTex, _widthDepth, _heigthDepth);
            secondTex = ResizeTextures(secondTex, _widthDepth, _heigthDepth);

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

                int score = correctPixels * 100 / _totalPixels;
                Debug.Log(correctPixels);
                Debug.Log("score: " + score + "%");
                Debug.Log(_totalPixels);

                _score = score;
            }
        }

        private Texture2D ResizeTextures(Texture2D resizeTexture, int targetX, int targetY)
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

            if (CalculateRGBValues(firstVector, secondVector, 0.1f))
            {
                return 1;
            }
            else
                return 0;
        }

        private bool CalculateRGBValues(Vector4 firstVector, Vector4 secondVector, float margin)
        {
            if (secondVector.w < 0.5f) //0.5f is jst a random low enough value to check if it has alpha(meaning it shouldnt count this pixel)
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


