using MexiColeccion.Hub;
using System;
using System.Collections;
using UnityEngine;

namespace MexiColeccion.UI
{
    /// <summary>
    /// This is the new version of the UIScriptMainHub Script (deleted)
    /// </summary>
    public class MainHubUI : BaseUI
    {
        [SerializeField] private GameObject _playerCharacter;
        [SerializeField] private GameObject _viewArtifactsButton;
        [SerializeField] private GameObject _hideArtifactsButton;
        [SerializeField] private GameObject _leftArrow, _rightArrow;
        [SerializeField] private GameObject _artifactViewer;
        [SerializeField] private Camera _cam;
        [SerializeField] private SoundManager _soundManager;

        private Animator _camAnimator;
        private Animator _artifactAnimator;

        /// <summary>
        /// 0 = idle; 1 = zoom out; 2 = zoom in;
        /// </summary>
        private int ViewerState
        {
            get => _camAnimator.GetInteger("ViewerState");
            set => _camAnimator.SetInteger("ViewerState", value);
        }

        internal event EventHandler<OnArrowTappedEventArgs> ArrowTapped;

        private void Start()
        {
            _soundManager.PlayHubBGM();
            _camAnimator = _cam.GetComponent<Animator>();
            _artifactAnimator = _artifactViewer.GetComponent<Animator>();
        }

        public void OnArtifactViewerClosed()
        {
            _soundManager.PlayButtonTap();
            ViewerState = 2;
            _hideArtifactsButton.SetActive(false);
            _artifactAnimator.SetBool("IsClosing", true);

            StartCoroutine(WaitForEndOfAnimation());
        }

        public void OnArtifactViewerOpened()
        {
            _soundManager.PlayButtonTap();
            ViewerState = 1;
            _artifactViewer.SetActive(true);
            _artifactAnimator.SetBool("IsClosing", false);

            SetActive(false, _viewArtifactsButton, _leftArrow, _rightArrow);
            _artifactViewer.transform.parent.gameObject.GetComponent<ArtifactViewer>().UpdatePosition();
            StartCoroutine(WaitForEndOfAnimation());
        }

        public void OnLeftArrowTapped()
        {
            if (ViewerState != 0)
                return;

            Debug.Log("TappedLeft");
            int direction = -1;

            OnArrowTapped(direction);
        }

        public void OnRightArrowTapped()
        {
            if (ViewerState != 0)
                return;

            Debug.Log("TappedRight");
            int direction = 1;

            OnArrowTapped(direction);
        }

        private void OnArrowTapped(int direction)
        {
            _soundManager.PlayButtonTap();

            _viewArtifactsButton.SetActive(false);

            EventHandler<OnArrowTappedEventArgs> handler = ArrowTapped;
            ArrowTapped?.Invoke(this, new OnArrowTappedEventArgs(direction, _viewArtifactsButton));
        }

        private IEnumerator WaitForEndOfAnimation()
        {
            yield return new WaitForSeconds(_camAnimator.GetCurrentAnimatorStateInfo(0).length);

            if (ViewerState == 1)
            {
                _hideArtifactsButton.SetActive(true);
            }
            if (ViewerState == 2)
            {
                _artifactViewer.SetActive(false);
                SetActive(true, _viewArtifactsButton, _leftArrow, _rightArrow);
                ViewerState = 0;
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void SetActive(bool active, params GameObject[] gameObjects)
        {
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(active);
            }
        }
    }

    internal class OnArrowTappedEventArgs
    {
        internal int Direction;
        internal GameObject ArtifactsButton;

        internal OnArrowTappedEventArgs(int direction, GameObject artifactsButton)
        {
            Direction = direction;
            ArtifactsButton = artifactsButton;
        }
    }
}
