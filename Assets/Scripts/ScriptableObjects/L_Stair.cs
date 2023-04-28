using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class L_Stair : Brick
{
    [SerializeField] private BoxCollider boxCollider;
        private bool isFilled = false;

    private void Awake()
    {
        colorType = -1;
    }
    public BoxCollider BoxCollider { get { return boxCollider; } set { boxCollider = value; } }
}
