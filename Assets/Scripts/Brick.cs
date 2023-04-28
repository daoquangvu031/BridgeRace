using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : L_ObjectColor
{
    public bool onbalo = false;

    public void SetRandomColor()
    {
        int randomColorType = Random.Range(0, 4);
        colorType = randomColorType;
        ColorT = (ColorType)randomColorType;
        Mesh.material = L_ColorDataManager.Ins.ColorData.GetMat((ColorType)colorType);
    }
    public void SetColor(int colo)
    {
        colorType = colo;
        Mesh.material = L_ColorDataManager.Ins.ColorData.GetMat((ColorType)colorType);
    }
}
