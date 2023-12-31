using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public AudioClip sfx;
    public AudioSource audiosource;
    public Volumes sfxV;
    public float delay = 1.0f;

    public Animator transtionAnim;

    private void Update()
    {
        audiosource.volume = sfxV.volume;
    }
    public void startgame()
    {
        audiosource.PlayOneShot(sfx);
        StartCoroutine(delayLoad(1));
    }    
    public void leaderBoard()
    {
        audiosource.PlayOneShot(sfx);
        StartCoroutine(delayLoad(3));
    }   
    public void gameInfo()
    {
        audiosource.PlayOneShot(sfx);
    }

    public void mainMenu()
    {
        audiosource.PlayOneShot(sfx);
        StartCoroutine(delayLoad(0));
    }

    public void settingMenu()
    {
        audiosource.PlayOneShot(sfx);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private IEnumerator delayLoad(int sceneIndex)
    {
        transtionAnim.SetTrigger("transition");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
