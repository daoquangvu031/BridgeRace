using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // Bắt đầu state
    void OnEnter(L_Bot enemy);

    // Thực hiện state
    void OnExecute(L_Bot enemy);

    // Kết thúc state
    void OnExit(L_Bot enemy);
}