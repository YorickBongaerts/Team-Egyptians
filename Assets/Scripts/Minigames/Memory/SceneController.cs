using UnityEngine;

namespace MexiColeccion.Minigames.Memory
{
    public class SceneController : MonoBehaviour
    {


        [SerializeField] private Sprite[] images;

        [SerializeField] private Transform parent;





        //-------------------------------------------------------------------------------------------------------------------------------------------



        //private int _score = 0;
        //[SerializeField] private TextMesh scoreLabel;
        //
        //[SerializeField] private MemoryMinigame memGame;
        //public bool canReveal
        //{
        //    get { return _secondRevealed == null; }
        //}
        //
        //public void CardRevealed(MainCard card)
        //{
        //    if (_firstRevealed == null)
        //    {
        //        _firstRevealed = card;
        //    }
        //    else
        //    {
        //        _secondRevealed = card;
        //        memGame.FlipCard(_firstRevealed,_secondRevealed);
        //        StartCoroutine(CheckMatch());
        //    }
        //}

        //private IEnumerator CheckMatch()
        //{
        //    if (_firstRevealed.id == _secondRevealed.id)
        //    {
        //        _score++;
        //        scoreLabel.text = "Score: " + _score;
        //    }
        //    else
        //    {
        //        yield return new WaitForSeconds(0.5f);
        //
        //        _firstRevealed.Unreveal();
        //        _secondRevealed.Unreveal();
        //    }
        //
        //    _firstRevealed = null;
        //    _secondRevealed = null;
        //
        //}
    }
}