    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBrick : MonoBehaviour
{   
    public Transform balo;
    public Transform dot;
    private float brickheight = 0.4f;
    public GameObject _brick;
    public Character character;
    public List<GameObject> brickList = new List<GameObject>();
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public SpawnBrick spawnBrick;
    Dictionary<Vector3, KeyValuePair<Color, int>> brickDictionary = new Dictionary<Vector3, KeyValuePair<Color, int>>();
    public void Start()
    {

    }
    public void addBrick()
    {
        GameObject obj = Instantiate(_brick, dot.position, transform.rotation);
        //brick.GetComponent<Rigidbody>().isKinematic = true;  
        obj.transform.SetParent(balo);
        obj.GetComponent<Brick>().onbalo = true;
        obj.GetComponent<MeshRenderer>().material.color = skinnedMeshRenderer.material.color;
        //Thêm gạch + tăng chiều cao nhân vật
        /* brick.transform.localPosition = new Vector3(0, pointBrick * 1.5f, 0);
         brick.transform.localRotation = Quaternion.Euler(0, 0, 0); //chỉnh độ xoay của brick về 0 so với thg cha*/
        dot.position += new Vector3(0, brickheight, 0);
        brickList.Add(obj);
        character.countBrick++;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Mất gạch
        if (collision.gameObject.CompareTag("TouchBrick") && collision.gameObject.GetComponent<MeshRenderer>().material.color != skinnedMeshRenderer.material.color && character.countBrick > 0)
        {
            character.countBrick--;
            dot.position -= new Vector3(0, 0.4f, 0);    
            Destroy(brickList[brickList.Count - 1]);
            brickList.Remove(brickList[brickList.Count - 1]);
            // Đỏi màu 
            collision.gameObject.GetComponent<MeshRenderer>().material.color = skinnedMeshRenderer.material.color;// Thay đổi màu của gạch bằng màu nhân vật
            // Block khi chưa có gạch
            collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        if (collision.gameObject.CompareTag("Brick") && (collision.gameObject.GetComponent<MeshRenderer>().material.color == skinnedMeshRenderer.material.color || collision.gameObject.GetComponent<MeshRenderer>().material.color == Color.gray))
        {
            addBrick();
            //StartCoroutine(spawnBrick.Spawn(other.transform.position));
                collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Brick") && other.gameObject.GetComponent<Brick>().onbalo == false && (other.gameObject.GetComponent<MeshRenderer>().material.color == skinnedMeshRenderer.material.color || other.gameObject.GetComponent<MeshRenderer>().material.color == Color.gray) && character.isFalling == false)
        {
            addBrick();
            //StartCoroutine(spawnBrick.Spawn(other.transform.position));
            other.gameObject.SetActive(false);
        }
        // Mất gạch
        if (other.gameObject.CompareTag("TouchBrick") && other.gameObject.GetComponent<MeshRenderer>().material.color != skinnedMeshRenderer.material.color && character.countBrick > 0)
        {
            character.countBrick--;
            dot.position -= new Vector3(0, 0.4f, 0);
            Destroy(brickList[brickList.Count - 1]);
            brickList.Remove(brickList[brickList.Count - 1]);
            // Đỏi màu 
            other.gameObject.GetComponent<MeshRenderer>().material.color = skinnedMeshRenderer.material.color;// Thay đổi màu của gạch bằng màu nhân vật
            // Block khi chưa có gạch
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true; 
        }
    }
    public void FallBrick()
    {
        for (int i = 0; i < brickList.Count; i++)
        {
            GameObject brick = brickList[i];
            brick.transform.SetParent(null);
            brick.GetComponent<MeshRenderer>().material.color = Color.gray;
            brick.GetComponent<BoxCollider>().isTrigger = false;
            Rigidbody rbbrick = brick.AddComponent<Rigidbody>();
            //rbbrick.freezeRotation = true;
            dot.position = balo.position;

            // Tạo giá trị ngẫu nhiên cho trục x, y, z của vị trí bắn của từng brick
            float x = Random.Range(-2f, 3f);
            float y = Random.Range(0f, 1f);
            float z = Random.Range(-2f, 2f);
            Vector3 explosionPosition = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);

            //float distance = Vector3.Distance(rbbrick.transform.position, explosionPosition);
            //float impact = 1 - (distance / explosionRadius);
            //rbbrick.AddExplosionForce(explosionForce * impact, explosionPosition, explosionRadius, upwardsModifier);
            character.countBrick--;
        }
    }
}
