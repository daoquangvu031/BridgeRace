using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ObjectColor : MonoBehaviour
{
    [SerializeField] private ColorType colorT;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] private Collider col;
    [SerializeField] protected ColorData colorData;
    public int colorType = -1;

    public void ChangeColor(int color)
    {
        colorType = color;
        colorT = (ColorType)color;
        mesh.material = colorData.GetMat((ColorType)color);
    }
    public MeshRenderer Mesh { get { return mesh; } set { mesh = value; } }

    public ColorType ColorT { get => colorT; set => colorT = value; }
    public Collider Col { get => col; set => col = value; }

}
