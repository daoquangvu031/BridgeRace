using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Random = UnityEngine.Random;

public class MoveBrickState : IState
{
    L_Brick closestBrick;
    int randomBrick;
    public void OnEnter(L_Bot enemy)
    {
        randomBrick = Random.Range(5, 15);
    }

    // Tìm đủ gạch chuyển sang đi lên Bridge
    public void OnExecute(L_Bot enemy)
    {
        enemy.ChangeAnim("Run");
        if (enemy.BrickCount < randomBrick)
        {
            closestBrick = enemy.GetNearestBrick();
            if (closestBrick != null)
            {
                enemy.agent.SetDestination(closestBrick.transform.position);
                enemy.ChangeAnim("Run");
            }
        }
        else
        {
            enemy.ChangeState(new MoveBridgeState());
        }
    }

    public void OnExit(L_Bot enemy)
    {

    }
}