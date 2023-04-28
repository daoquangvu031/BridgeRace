using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Under2 : MonoBehaviour
{
    public SkinnedMeshRenderer colorCollider;
    private void Start()
    {

    }
    // Hàm xử lý va chạm
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            GameObject obj = transform.parent.gameObject; // Lấy Floor2
            GameObject son = obj.transform.GetChild(0).gameObject; // Lấy BrickS2
            //son.SetActive(true);
            List<GameObject> listbrick = new List<GameObject>();
            int countChill = son.transform.childCount;
            for (int i = 0; i < countChill; i++)
            {
                listbrick.Add(son.transform.GetChild(i).gameObject);
            }
            colorCollider = collision.gameObject.GetComponent<Character>().skinnedMeshRenderer; // Gán giá trị cho biến currentSkinnedMeshRenderer
            if (colorCollider == null)
            {
                return;
            }
            foreach (GameObject go in listbrick)
            {
                if (!go.activeSelf && go.GetComponent<MeshRenderer>().material.color == colorCollider.material.color)
                {
                    go.SetActive(true);
                }
            }

        }
    }

    // Hàm xử lý cập nhật
    void Update()
    {

    }
}