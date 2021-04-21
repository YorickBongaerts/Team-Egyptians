using System;
using System.Collections;
using UnityEngine;

namespace MexiColleccion.UI
{
    /// <summary>
    /// This is the new version of the UIScriptMainHub Script (deleted)
    /// </summary>
    public class MainHubUI : BaseUI
    {
        [SerializeField] private GameObject _playerCharacter;
        [SerializeField] private GameObject _viewArtifactsButton;
        [SerializeField] private GameObject _hideArtifactsButton;
        [SerializeField] private GameObject _artifactsViewer;
        [SerializeField] private Camera _cam;
        
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
            _camAnimator = _cam.GetComponent<Animator>();
            _artifactAnimator = _artifactsViewer.GetComponent<Animator>();
        }

        public void OnArtifactViewerClosed()
        {
            ViewerState = 2;
            _hideArtifactsButton.SetActive(false);
            _artifactAnimator.SetBool("IsClosing", true);
            StartCoroutine(WaitForEndOfAnimation());
        }

        public void OnArtifactViewerOpened()
        {
            ViewerState = 1;
            _viewArtifactsButton.SetActive(false);
            _artifactAnimator.SetBool("IsClosing", false);
            _artifactsViewer.SetActive(true);
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
                _artifactsViewer.SetActive(false);
                _viewArtifactsButton.SetActive(true);
                ViewerState = 0;
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
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
