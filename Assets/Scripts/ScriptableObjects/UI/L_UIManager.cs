using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_UIManager : Singleton<L_UIManager>
{
    [SerializeField] public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseUI;
    [SerializeField] public GameObject resumeUI;
    public GameObject victoryUI;
    public GameObject loseUI;
    public void Resume()
    {
        pauseUI.SetActive(true);
        resumeUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void GotoHome()
    {
        SceneManagerment.Ins.GoHome("MainMenu");
    }

    public void ResetGame()
    {
        SceneManagerment.Ins.ResetGame();
    }
    public void Pause()
    {
        resumeUI.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Victory()
    {
        victoryUI.SetActive(true);
        loseUI.SetActive(false);
        Pause();
    }
    public void Lose()
    {
        loseUI.SetActive(true);
        victoryUI.SetActive(false);
        Pause();

    }
    public void NextLevel(string Level)
    {
        SceneManagerment.Ins.NextLevel(Level);
    }
}
