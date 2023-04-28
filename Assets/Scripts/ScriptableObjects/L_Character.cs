using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class L_Character : L_ObjectColor
{
    [SerializeField] protected Transform balo;
    [SerializeField] protected Transform dot;
    [SerializeField] private float brickHeight = 0.4f;
    [SerializeField] protected L_Brick brickPrefab;
    [SerializeField] Animator Anim;
    [SerializeField] string currentAnimName;
    public int countBrick = 0;
    public List<L_Brick> brickList = new List<L_Brick>();
    public bool isFalling = false;

    Stage stage;

    public int BrickCount => brickList.Count;


    public void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void AddBrick()
    {
        L_Brick brick = Instantiate(brickPrefab, dot.position + new Vector3(0, 0.4f, 0) * BrickCount, transform.rotation);
        brick.transform.SetParent(balo);
        brick.ChangeColor(colorType);
        brickList.Add(brick);
        countBrick++;
    }
    public void RemoveBrick()
    {
        if (brickList.Count > 0)
        {
            L_Brick brick = brickList[brickList.Count - 1];
            brickList.RemoveAt(brickList.Count - 1);
            Destroy(brick.gameObject);
            countBrick--;
        }
    }

    public void ClearBrick()
    {
        while (brickList.Count > 0)
        {
            L_Brick brick = brickList[brickList.Count - 1];
            brickList.RemoveAt(brickList.Count - 1);
            Destroy(brick.gameObject);
        }
    }

    public void FallBrick()
    {
        for (int i = 0; i < brickList.Count; i++)
        {
            L_Brick brick = brickList[i];
            brick.transform.SetParent(null);
            brick.GetComponent<L_Brick>().colorType = (int)ColorType.Gray;
            brick.GetComponent<BoxCollider>().isTrigger = false;
            Rigidbody rbbrick = brick.gameObject.AddComponent<Rigidbody>();
            //rbbrick.freezeRotation = true;
            

            // Tạo giá trị ngẫu nhiên cho trục x, y, z của vị trí bắn của từng brick
            float x = Random.Range(-2f, 3f);
            float y = Random.Range(0f, 1f);
            float z = Random.Range(-2f, 2f);
            Vector3 explosionPosition = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
            countBrick--;
        }
        dot.position = balo.position;
        brickList.Clear();
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            Anim.ResetTrigger(animName);
            currentAnimName = animName;
            Anim.SetTrigger(currentAnimName);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick") && other.gameObject.GetComponent<L_Brick>().onbalo == false
            && (other.gameObject.GetComponent<L_Brick>().colorType == colorType || other.gameObject.GetComponent<L_Brick>().colorType == (int)ColorType.Gray)
            && isFalling == false)
        {
            AddBrick();
            L_Brick brick = other.GetComponent<L_Brick>();
            if (brick != null)
            {
                brick.SelfRespawn();    
            }
        }
        if (other.gameObject.CompareTag("TouchBrick") && other.gameObject.GetComponent<L_Stair>().colorType != colorType && countBrick > 0)
        {
            L_Stair stair = other.gameObject.GetComponent<L_Stair>();
            stair.BoxCollider.isTrigger = true;
            stair.SetColor((int)colorType);
            RemoveBrick();
        }

    }
    public virtual void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("TouchBrick") && collision.gameObject.GetComponent<L_Stair>().colorType != colorType && countBrick > 0)
        {
            L_Stair stair = collision.gameObject.GetComponent<L_Stair>();
            stair.BoxCollider.isTrigger = true;
            stair.SetColor((int)colorType);
            RemoveBrick();
        }
        if (collision.gameObject.CompareTag("Brick") && collision.gameObject.GetComponent<L_Brick>().onbalo == false
            && (collision.gameObject.GetComponent<L_Brick>().colorType == colorType || collision.gameObject.GetComponent<L_Brick>().colorType == (int)ColorType.Gray)
            && isFalling == false)
        {
            AddBrick();
            L_Brick brick = collision.gameObject.GetComponent<L_Brick>();
            if (brick != null)
            {
                brick.SelfRespawn();
            }
        }
    }
    public List<L_Brick> BrickList { get; private set; }
}
