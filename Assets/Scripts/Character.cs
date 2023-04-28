using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;


public class Character : MonoBehaviour
{
    public int countBrick = 0;
    public bool isFalling = false;
    public ColorType colorType;
    public Color currentColor;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Color GetColor()
    {
        return currentColor;
    }

}
