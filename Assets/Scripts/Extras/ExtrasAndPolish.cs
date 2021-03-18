using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MexiColleccion.Extras
{
    public class ExtrasAndPolish : MonoBehaviour
    {
        //The parts that were written in the extra's part of the tech analyses
        //Wasn't sure if these were all meant to be methods since post production are on the camera and such

        private void UIUX()
        {
            //Needs to work with the main hub
        }

        private void UIUXMainHub()
        {
            //UI elements needed to be implemented for the main hub
            //This means visualisation of controls(joystick when walking around and buttons when going through a menu), settings button and counter with amound of collected artifacts
        }

        private void UIUXMemoryGame()
        {
            //UI elements needed to be implemented for the Memory game minigame
            //This includes a symbol to display how many attempts the player has left, the visualisation of the times, and the number of correctly guessed pairs
            //We would also like to make a small visual clue for when the player taps something
        }

        private void UIUXTeotihuacanTechnician()
        {
            //UI elements needed to be implemented for the Teotihuacan technician minigame
            //In this case, the needed UI will be a HUD, displaying how much in the player still has and the accuracy te player has drawn with
            //There will also be an overlay which shows the player what to draw. This overlay will become less solid when drawing and more solid when not
        }

        private void Menus()
        {
            //Menu logic
        }

        private void StartMenu()
        {
            //Start game (button)
            //Back to start menu (button)
        }

        private void OptionsMenu()
        {
            //Control sound
            //Back to start menu (button)
        }

        private void PauseMenu()
        {
            //Pause game
            //Continue game (button)
            //Quit game (button)
        }

        private void CameraMainHub()
        {
            //The camera needs to feel smooth, meaning that when scrolling through the minigame menu or the artifact viewer menu, the camera should smoothly move over to the next item in the list
            //The camera should also nicely follow the player, meaning it can’t clip into walls and doesn’t move all jittery
        }

        private void CameraMemoryGame()
        {
            //The camera in this minigame will mostly be static, except for some screenshake when the player makes a mistake and a smooth zoom-out for when we want to show the acquired artifact after the player has won
        }

        private void CameraTeotihucanTechnician()
        {
            //The camera in this minigame will also be mostly static, but it will turn along with the curve of the line the player is drawing.This camera will also zoom -out a little when the player has won / collected an artifact
        }

        private void PostFXMainHub()
        {
            //Additional effects needed in the main hub to give a more polished feel
            //Fixing lighting so it shines nicely on all important parts
            //Necessary sound effects (button tapping)
        }

        private void PostFXMemoryGame()
        {
            //Additional effects needed in the memory game minigame to give a more polished feel
            //Fixing lighting so it shines nicely on all important parts
            //Confetti-like an effect when guessing cards correctly
            //Thunder cloud effect when guessing cards wrong
            //Necessary sound effects (cheering and thunder)
        }

        private void PostFXTeotihuacanTechnician()
        {
            //Additional effects needed in the Teotihuacan Technician minigame to give a more polished feel
            //Fixing lighting so it shines nicely on all important parts
            //Small effect of ink splashes when drawing
            //Necessary sound effects(drawing and erasing)
        }
    }
}