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
        [SerializeField] private GameObject _artifactViewer;
        [SerializeField] private Camera _cam;
        
        private Animator _animator;

        internal event EventHandler<OnArrowTappedEventArgs> ArrowTapped;

        public void OnArtifactViewerClosed()
        {
            _animator = _artifactViewer.GetComponentInChildren<Animator>();
            _animator?.SetBool("IsClosed", true);
            _cam.GetComponent<Animator>().SetInteger("ViewerState", 0);
            StartCoroutine(WaitForEndOfAnimation());
        }

        public void OnArtifactViewerOpened()
        {
            _cam.GetComponent<Animator>().SetInteger("ViewerState", 1);
            _artifactViewer.SetActive(true);
            _viewArtifactsButton.SetActive(false);
        }

        public void OnLeftArrowTapped()
        {
            if (_artifactViewer.activeSelf)
                return;

            Debug.Log("TappedLeft");
            int direction = -1;

            OnArrowTapped(direction);
        }

        public void OnRightArrowTapped()
        {
            if (_artifactViewer.activeSelf)
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
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

            _artifactViewer.SetActive(false);
            _viewArtifactsButton.SetActive(true);
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
