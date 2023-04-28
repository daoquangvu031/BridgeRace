using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorBrick : MonoBehaviour
{
    public Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.gray };
    public List<GameObject> brickList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject obj = this.transform.GetChild(i).gameObject;
            brickList.Add(obj);
        }
        for (int i = 0; i < brickList.Count; i++)
        {
            brickList[i].GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, 4)];
        }
    }
    private void Update()
    {

    }
}