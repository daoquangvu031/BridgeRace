
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerment : Singleton<SceneManagerment>
{
    static int num = 0;


    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel(string nameScene)
    {
        num++;
        nameScene = nameScene + num.ToString();
        GoToScene(nameScene);
    }
    public void GoHome(string nameScene)
    {
        GoToScene(nameScene);
    }
    

    
}