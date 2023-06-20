using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("POO");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Extras()
    {
        SceneManager.LoadScene("Extras");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
