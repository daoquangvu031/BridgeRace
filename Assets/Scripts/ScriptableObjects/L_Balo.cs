using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Balo : L_ObjectColor
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {

        }

        L_Character character = other.GetComponent<L_Character>();

        if (character != null && colorType == character.colorType)
        {
            character.AddBrick();
            Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
    }

}
