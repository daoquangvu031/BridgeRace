using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridgeState : IState
{
    bool isBridge = false;
    public void OnEnter(L_Bot enemy)
    {

    }

    // Đi lên cầu đến khi hết gạch
    public void OnExecute(L_Bot enemy)
    {
        enemy.ChangeAnim("Run");
        enemy.agent.SetDestination(enemy.target.position);
        Vector3 positionEnemy = enemy.transform.position;
        if (Mathf.Sqrt((positionEnemy.x - enemy.target.position.x) * (positionEnemy.x - enemy.target.position.x) + (positionEnemy.z - enemy.target.position.z) * (positionEnemy.z - enemy.target.position.z)) < 0.2f)
        {
            //enemy.Victory();
        }
        else if (enemy.BrickCount == 0)
        {
            enemy.agent.velocity = Vector3.zero;
            enemy.ChangeState(new MoveBrickState());
        }
    }

    public void OnExit(L_Bot enemy)
    {

    }
}