using MexiColeccion.Hub;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Minigames
{
    public class MinigameBaseClass : MonoBehaviour
    {
        // TODO: what is ectually being used of this class?

        //Tibo and Vincent
        //Make a base class for both minigames

        //Tibo check for the artist minigame
        //Vincent check for the memory minigame

        //Delegates??


        #region Privates

        private GameObject[] _collectedArtifacts;
        private GameObject[] _minigameSpecificArtifacts;
        private GameObject _collectibleArtifact;
        private float _score;
        private float _timeRemaining = 10;
        private int _amountOfArtifacts;
        private bool _hasGoodThingHappened;
        private bool _isGameActive; // could be a static field in a game loop manager
        private bool _isTimeRunning = true;
        private bool _winningClause;

        #endregion Privates

        #region Publics
        public HubScript HubScript;

        public Text timeText;

        public float _scoreIncrease = 1;
        public float Score { get; internal set; }
        #endregion Publics

        private void Update()
        {
            //UpdateTimer();
        }

        #region Methods
        protected virtual void ScoreSystem()
        {
            //The score system will hold the scope of the player
            //The way in which the points are calculated varies between minigames and will be coded in their respective scripts
            if (_hasGoodThingHappened)
            {
                _score += _scoreIncrease;
                //Extra things
                Score = _score;
            }
        }

        private void StartMinigame()
        {
            //Start the minigame
            //Call and activate the chosen minigame

            _isGameActive = true;
        }

        private GameObject RandomArtifact(GameObject[] minigameSpecificArtifacts) //Link/difference with the method in the HubScript?
        {
            //Select an artifact randomly from the dictionary of artifacts
            //Prompt this artifact to be rewarded to the player (ui?)

            //Chooses a random artifact that has not yet been collected

            //Removing of already collected pieces
            foreach (var collectedArtifact in _collectedArtifacts)
            {
                string nameToRemove = collectedArtifact.name;
                minigameSpecificArtifacts = minigameSpecificArtifacts.Where(name => name.name == nameToRemove).ToArray();
            }

            _amountOfArtifacts = minigameSpecificArtifacts.Length;
            return _collectibleArtifact = minigameSpecificArtifacts[Random.Range(0, _amountOfArtifacts)];
        }

        private void WinMinigame() //Vague conditions to be overwritten in the minigameSpecificClasses?
        {
            //Conditions on when to win the minigame
            //Return true if won
            _winningClause = true;

            /*
            if(play cut scene)
                EndMinigame()
            
            */
        }

        private void CollectArtifact()
        {
            //Get the result of the RandomArtifact class
            //Remove this selected artifact from the dictionary
            //Add it to the list of already achieved artifacts (Where do we put this list?)
            //Show the artifact that the player gets

            GameObject randomArtifact = RandomArtifact(_minigameSpecificArtifacts);
            //StuffToSaveScript.CollectedArtifacts.Add(randomArtifact);
        }

        public void EndMinigame(bool hasWon)
        {
            if (hasWon)
                WinMinigame();
            else
                LoseMinigame();
            //End condition of the minigame
            //Based on win or lose minigame
            //Show right ui/scene
            _isGameActive = false;

            HubScript.LoadHub();
        }
        private void LoseMinigame()
        {
            /*
            if(play cut scene)
                EndMinigame()
            */

            //Conditions on when to lose the minigame
            //Return true if lost  OR return a false for win condition
            _winningClause = false;
        }

        private void UpdateTimer()
        {
            //Timer
            //Display in the UI
            //Get an int value, so that it can be specified per minigame



            //https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

            if (_isTimeRunning)
            {
                if (_timeRemaining > 0)
                {
                    _timeRemaining -= Time.deltaTime;

                    //timeRemaining += 1;
                    float minutes = Mathf.FloorToInt(_timeRemaining / 60);
                    float seconds = Mathf.FloorToInt(_timeRemaining % 60);

                    Debug.Log("Timer: " + minutes + " minutes and " + seconds + " seconds.");

                    timeText.text = string.Format("{0:00}:{0:00}", minutes, seconds);
                }
                else
                {
                    Debug.Log("Time has run out");
                    _timeRemaining = 0;
                    _isTimeRunning = false;
                }
            }
        }

        private void LoseWhenTimeRunsOut()
        {
            //Loses the minigame when the timer reaches 0

            if (!_isTimeRunning)
                EndMinigame(false);
        }
        #endregion Methods
    }
}