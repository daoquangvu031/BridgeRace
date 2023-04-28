using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObjects/ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    [SerializeField] public Material[] mats;

    public Material GetMat(ColorType colorType)
    {
        return mats[(int)colorType];
        
    }
}
public enum ColorType { Red = 0, Blue = 1, Green = 2, Black = 3, Gray = 4, White = 5 }
