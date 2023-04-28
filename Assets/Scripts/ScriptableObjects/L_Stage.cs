using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Stage : MonoBehaviour
{
    List<L_Brick> l_Bricks = new List<L_Brick>();
    public L_Brick BrickPrefab;
    public List<L_Brick> brickList = new List<L_Brick>();
    public float ReSpawnTime = 10f;
    public float timer = 0f;
    private bool canspawnbrick = false;

    //void Awake()
    //{
    //    for (int i = 0; i < brickList.Count; i++)
    //    {
    //        brickList[i].gameObject.SetActive(false);
    //    }
    //    /*for (int i = 0; i < this.transform.childCount; i++)
    //     {
    //        Brick brick = transform.GetChild(i).gameObject.GetComponent<Brick>();
    //        brickList.Add(brick);
    //    }*/
    //    /*for (int i = 0; i < brickList.Count; i++)
    //    {
    //        brickList[i].SetRandomColor();          
    //    }*/
    //}
    void Update()
    {
        //if (canspawnbrick)
        //{
        //     cập nhật timer
        //    timer += Time.deltaTime;
        //    if (timer >= ReSpawnTime)
        //    {
        //         reset timer
        //        timer = 0f;
        //         gọi coroutine để spawn lại các viên gạch
        //        RespawnBricks();
        //    }
        //}
    }
    public void RespawnBricks()
    {
        // Duyệt qua danh sách các viên gạch đã set active false trước đó
        foreach (L_Brick brick in brickList)
        {
            if (!brick.gameObject.activeSelf)
            {
                // Set active true lại viên gạch
                brick.gameObject.SetActive(true);
                brick.GetComponent<L_Brick>().SetRandomColor();

            }
        }
    }
    // Hàm xử lý va chạm
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.CompareTag("character"))
        {
            canspawnbrick = true;

            RespawnBricks();
            //GameObject obj = transform.parent.gameObject; // Lấy Floor2
            //GameObject son = obj.transform.GetChild(0).gameObject; // Lấy BrickS2
            //son.SetActive(true);
            //List<GameObject> listbrick = new List<GameObject>();
            //int countChill = son.transform.childCount;
            //for (int i = 0; i < countChill; i++)
            //{
            //    listbrick.Add(son.transform.GetChild(i).gameObject);
            //}
            //colorCollider = other.GetComponent<Character>().skinnedMeshRenderer; // Gán giá trị cho biến currentSkinnedMeshRenderer
            L_Character character = other.GetComponent<L_Character>();
            if (character != null)
            {
                ColorType colorType = character.ColorT;
                Debug.Log(colorType);
                for (int i = 0; i < brickList.Count; i++)
                {
                    if (brickList[i].ColorT == colorType)
                    {
                        brickList[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        brickList[i].gameObject.SetActive(false);
                    }
                }
            }
            //foreach (L_Brick go in brickList)
            //{
            //    Debug.Log(go.colorType);
            //    if (!go.gameObject.activeSelf && go.colorType == other.GetComponent<L_Character>().colorType)
            //    {
            //        go.gameObject.SetActive(true);
            //    }
            //}

        }
    }
    /*public Vector3 SeekBrick(ColorType colorType) 
    {
        for (int i = 0; i < l_Bricks.Count; i++)
        {
            if (l_Bricks[i] != null && l_Bricks[i].colorType == (int)colorType)
            {
                return l_Bricks[i].transform.position;
            }
        }

        return Vector3.zero;
    }*/

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("character"))
    //    {
    //        GameObject obj = transform.parent.gameObject; // Lấy Floor2
    //        GameObject son = obj.transform.GetChild(0).gameObject; // Lấy BrickS2
    //        //son.SetActive(true);
    //        List<GameObject> listbrick = new List<GameObject>();
    //        int countChill = son.transform.childCount;
    //        for (int i = 0; i < countChill; i++)
    //        {
    //            GameObject go = son.transform.GetChild(i).gameObject;
    //            //listbrick.Add(son.transform.GetChild(i).gameObject);
    //            if (go.GetComponent<L_Brick>().colorType == collision.gameObject.GetComponent<L_Character>().colorType)
    //            {
    //                listbrick.Add(go);
    //            }

    //        }
    //        //colorType = collision.gameObject.GetComponent<L_Character>().colorType; // Gán giá trị cho biến currentSkinnedMeshRenderer
    //        //if (colorType == -1)
    //        //{
    //        //    return;
    //        //}
    //        foreach (GameObject go in listbrick)
    //        //{
    //            //if (!go.activeSelf && go.GetComponent<L_Brick>().colorType == colorType)
    //            {
    //                go.SetActive(true);
    //            }
    //        //}

    //    }
    //}
}
