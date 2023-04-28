using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_LevelManager : Singleton<L_LevelManager>
{
    [SerializeField] L_Level[] levels;
    private L_Level currentLevel;
    private int level = 0;

    public void LoadLevel(int level)
    {

    }

    public void OnInitLevel()
    {

    }

    public void OnWin()
    {

    }

    public void OnLose()
    {

    }
}
