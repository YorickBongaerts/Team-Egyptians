using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MexiColeccion.Utils
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private readonly float _setTransitionTime = 1.0f;
        [SerializeField] private GameObject _setCrossFade, _setLeaves;
        [SerializeField] private Animator _transitionAnimator;

        public static LevelLoader Instance;
        public static Animator TransitionAnimator;
        private static GameObject _crossFade, _leaves;
        private static float _transitionTime;

        private void Awake()
        {
            Instance = this;
            TransitionAnimator = _transitionAnimator;
            _transitionTime = _setTransitionTime;
            _crossFade = _setCrossFade;
            _leaves = _setLeaves;

            DontDestroyOnLoad(transform.gameObject);
        }

        internal static void LoadNextLevel(string scene)
        {
            Instance.StartCoroutine(LoadLevelAsync(scene));
        }

        internal static void LoadNextLevel(string scene, string animationType)
        {
            Instance.StartCoroutine(LoadLevelAsync(scene, animationType));
        }

        internal static string GetCurrentLevelName()
        {
            return SceneManager.GetActiveScene().name;
        }

        private static IEnumerator LoadLevelAsync(string scene)
        {
            //LoadScene
            var operation = SceneManager.LoadSceneAsync(scene);

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / .0f);
                UnityEngine.Debug.Log(progress);

                // wait for next frame
                yield return null;
            }
        }

        private static IEnumerator LoadLevelAsync(string scene, string animationType)
        {
            switch (animationType)
            {
                case "CrossFade":
                    _transitionTime = 1.0F;
                    _crossFade.SetActive(true);
                    break;
                case "Leaves":
                    _transitionTime = 3.0F;
                    _leaves.SetActive(true);
                    break;
            }

            UnityEngine.Debug.LogFormat("animation type is {0} {1}", animationType, _transitionTime);

            //play animation
            TransitionAnimator.Play(animationType);

            //wait
            yield return new WaitForSeconds(_transitionTime);

            //LoadScene
            var operation = SceneManager.LoadSceneAsync(scene);

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / .01f);
                UnityEngine.Debug.Log(progress);

                // wait for next frame
                yield return null;
            }

            //play end animation
            TransitionAnimator.SetTrigger("isPlaying");

            //wait
            yield return new WaitForSeconds(_transitionTime);

            if (_leaves.activeSelf)
                _leaves.SetActive(false);
            else if (_crossFade.activeSelf)
                _crossFade.SetActive(false);
        }
    }
}