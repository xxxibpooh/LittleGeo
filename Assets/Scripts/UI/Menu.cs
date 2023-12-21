using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator exitOrNotAnimator;

    public void NewGame()
    {
        TransitionManager.Instance.StartGameTransition();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        //
    }
    public void CheckExitButton()
    {
        exitOrNotAnimator.SetBool("IsCheck", true);
        EventHandler.CallGameStateChangeEvent(GameState.Pause);
    }
    public void NoButton()
    {
        
        exitOrNotAnimator.SetBool("IsCheck", false);
        EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
    }
    public void GoBackToMenu()
    {
        var currentScene=SceneManager.GetActiveScene().name;
        TransitionManager.Instance.Transition(currentScene, "Menu");
    }
}
