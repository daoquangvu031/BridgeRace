using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class L_Brick : Brick
{
    [SerializeField] private float spawnTime;
    [SerializeField] private bool isActivate;

    public bool IsActivate { get => isActivate; set => isActivate = value; }

    private void Awake()
    {
        SetRandomColor();
        isActivate = true;
    }

    public void SelfRespawn()
    {
        StartCoroutine(CoRespawn());
    }

    private IEnumerator CoRespawn()
    {
        isActivate = false;
        Mesh.enabled = false;
        Col.enabled = false;
        yield return new WaitForSeconds(spawnTime);
        Mesh.enabled = true;
        Col.enabled = true;
        isActivate = true;
    }
    /*public Transform balo;
    public Transform dot;
    private float brickheight = 0.4f;
    public GameObject _brick;
    public L_Character character;
    public List<Brick> brickList = new List<Brick>();
    public SpawnBrick spawnBrick;
    public int countBrick = 0;
    Dictionary<Vector3, KeyValuePair<ColorType, int>> brickDictionary = new Dictionary<Vector3, KeyValuePair<ColorType, int>>();
    public void Start()
    {

    }
    public void addBrick()
    {
        GameObject obj = Instantiate(_brick, dot.position, transform.rotation);
        //brick.GetComponent<Rigidbody>().isKinematic = true;  
        obj.transform.SetParent(balo);
        obj.GetComponent<Brick>().onbalo = true;
        obj.GetComponent<MeshRenderer>().material = L_ColorDataManager.Ins.ColorData.GetMat(colorType);
        //Thêm gạch + tăng chiều cao nhân vật
        *//* brick.transform.localPosition = new Vector3(0, pointBrick * 1.5f, 0);
         brick.transform.localRotation = Quaternion.Euler(0, 0, 0); //chỉnh độ xoay của brick về 0 so với thg cha*//*
        dot.position += new Vector3(0, brickheight, 0);
        //brickList.Add();
        character.countBrick++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick") && other.gameObject.GetComponent<Brick>().onbalo == false 
            && (other.gameObject.GetComponent<Brick>().color == colorType || other.gameObject.GetComponent<Brick>().color == ColorType.Gray) 
            && character.isFalling == false)
        {
            addBrick();
            //StartCoroutine(spawnBrick.Spawn(other.transform.position));
            other.gameObject.SetActive(false);
        }
        // Mất gạch
    }*/
}               