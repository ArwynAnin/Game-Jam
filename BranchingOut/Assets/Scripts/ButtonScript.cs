using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]private float transitionDuration = 1.0f;
    [SerializeField]private float delayDuration = .5f;

    public void startgame()
    {
        SceneManager.LoadScene(1);
    }    
    public void leaderBoard()
    {
        SceneManager.LoadScene(3);
    }   
    public void gameInfo()
    {
        SceneManager.LoadScene(4);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
