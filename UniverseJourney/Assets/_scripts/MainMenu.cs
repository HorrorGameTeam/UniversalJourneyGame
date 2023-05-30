using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SeeStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void SeeRules()
    {
        SceneManager.LoadScene("Rules");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BackfromRules()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
