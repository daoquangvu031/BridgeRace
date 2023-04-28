using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinLose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("character"))
        {
            if (other.GetComponent<L_Player>() != null)
            {
                L_UIManager.Ins.Victory();
            }
            else
            {
                L_UIManager.Ins.Lose();
            }
        }
    }
}
