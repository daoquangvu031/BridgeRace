 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class L_Bot : L_Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    public Transform target ;
    public NavMeshAgent agent;
    public float speed = 5;
    public ColorData cd;
    public L_Brick[] bricks1;
    public L_Brick[] bricks2;
    bool isDead = false;
    float maxrx;
    float timer = 2;
    int zone = 0;
    int intTarget;
    private bool isPause = false;
    private int randomBridge = -1;
    private IState currentState;
    private Vector3 currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new MoveBrickState());
        ChangeColor(colorType);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            return;
        }
        if (timer < 1f)
        {
            timer += Time.fixedDeltaTime;
            agent.velocity = Vector3.zero;
            isDead = true;
            return;
        }
        else
        {
            isDead = false;
        }
        //// Nếu currentState khác null và không chết thực hiện state
        if (currentState != null && !isDead)
        {
            currentState.OnExecute(this);
        }
    }
    // Thay đổi state của Enemy
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    // Tìm viên gạch gần nhất
    public L_Brick GetNearestBrick()
    { 
        float closestDistance = Mathf.Infinity;
        L_Brick closestBrick = null;
        if (zone == 0)
        {
            foreach(L_Brick brick in bricks1)
            {
                if (brick.colorType == colorType && brick.IsActivate)
                {
                    float distance = Vector3.Distance(transform.position, brick.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestBrick = brick;
                    }
                }
            }
        } else
        {
            foreach (L_Brick brick in bricks2)
            {
                if (brick.colorType == colorType && brick.IsActivate)
                {
                    float distance = Vector3.Distance(transform.position, brick.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestBrick = brick;
                    }
                }
            }
        }
        return closestBrick;
    }


    //public void Victory()
    //{
    //    ChangeAnim("Victory");
    //    while (countBrick != 0)
    //    {
    //        Destroy(brickList[brickList.Count - 1]);
    //        brickList.Remove(brickList.Count - 1);
    //    }
    //    UIManager.Ins.CloseUI<GamePlay>();
    //    UIManager.Ins.OpenUI<Defeat>();
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // va chạm với character có nhiều gạch hơn
    //    if (collision.gameObject.CompareTag("character"))
    //    {

    //        L_Character cha = collision.gameObject.GetComponent<L_Character>();
    //        if (cha != null)
    //        {
    //            if (cha.stackbrick.countbrick > stackbrick.countbrick)
    //            {
    //                fall();
    //                fallbrick();
    //                stackbrick.gameobject.setactive(false);
    //            }
    //        }
    //    }
    //}
    public IEnumerator ResetIsFallingAfterSeconds()
    {
        yield return new WaitForSeconds(2f);
        agent.enabled = true;
        //agent.SetDestination(currentTarget);
        ChangeState(new MoveBrickState());
        isFalling = false;
        Bot bot = GetComponent<Bot>();
        if (bot != null)
        {
            ChangeAnim("Run");
        }
        else
        {
            ChangeAnim("Idle");
        }
    }
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.tag == "character")
        {
            if (collision.gameObject.GetComponent<L_Character>().countBrick > GetComponent<L_Character>().countBrick)// Nếu số gạch của character kia lớn hơn số gạch của character này thì
            {
                ChangeAnim("Falling");
                // Ngã
                agent.velocity = Vector3.zero;
                isFalling = true;
                ChangeState(null);
                agent.SetDestination(transform.position);
                GetComponent<L_Character>().FallBrick(); // Gọi hàm FallBrick từ AddBirck 
                StartCoroutine(ResetIsFallingAfterSeconds());// Bắt đầu đếm thời gian để character đứng dậy
            }
        }
    }
    public void ChangeColor(int color)
    {
        colorType = color;
        ColorT = (ColorType)color;
        skinnedMeshRenderer.material = cd.GetMat((ColorType)colorType);
    }

   
    private void OnCollisionExit(Collision collision)
    {

    }
    public Rigidbody RB
    {
        get { return rb; }
        set { rb = value; }
    }
    public int Zone
    {
        get { return zone; }
        set { zone = value; }
    }
    public int IntTarget
    {
        get { return intTarget; }
        set { intTarget = value; }
    }
    public int RandomBridge
    {
        get { return randomBridge; }
        set { randomBridge = value; }
    }
    public bool IsPause
    {
        get { return isPause; }
        set { isPause = value; }
    }
}
