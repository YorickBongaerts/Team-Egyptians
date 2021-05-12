using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader _levelLoader;
    public static Animator Transition;
    private static float _transitionTime;
    private static GameObject _crossFade, _leaves;
    [SerializeField] private readonly float setTransitionTime = 1.0f;
    [SerializeField] private GameObject _setCrossFade, _setLeaves;
    [SerializeField] private Animator setTransition;

    private void Awake()
    {
        _levelLoader = this;
        Transition = setTransition;
        _transitionTime = setTransitionTime;
        _crossFade = _setCrossFade;
        _leaves = _setLeaves;

        DontDestroyOnLoad (transform.gameObject);
    }

    internal static void LoadNextLevel(string scene, string animationType)
    {
        _levelLoader.StartCoroutine(LoadLevelAsync(scene, animationType));
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

        Debug.LogFormat("animation type is {0} {1}", animationType, _transitionTime);

        //play animation
        Transition.Play(animationType);

        //wait
        yield return new WaitForSeconds(_transitionTime);

        //LoadScene
        var operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .0f);
            Debug.Log(progress);

            // wait for next frame
            yield return null;
        }

        //play end animation
        Transition.SetTrigger("isPlaying");

        //wait
        yield return new WaitForSeconds(_transitionTime);

        if (_leaves.activeSelf)
            _leaves.SetActive(false);
        else if (_crossFade.activeSelf) _crossFade.SetActive(false);
    }
}