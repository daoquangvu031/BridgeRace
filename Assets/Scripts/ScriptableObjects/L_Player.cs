using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Player : L_Character
{
    // Di chuyển Joystick
    [SerializeField] public FloatingJoystick joystick;
    [SerializeField] public float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private Rigidbody rb;

    public Vector3 moveVector;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Oninit();
    }


    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            L_UIManager.Ins.Victory();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            L_UIManager.Ins.Lose();
        }
    }

    protected void Oninit()
    {
        rotateSpeed = 3f;
        moveSpeed = 6f;
    }

    public void Move()
    {
        if (joystick != null)
        {
            moveVector = Vector3.zero;
            moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
            moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(direction);

                ChangeAnim("Run");
            }
            else if (joystick.Horizontal == 0 && joystick.Vertical == 0)
            {

                ChangeAnim("Idle");
            }

            rb.MovePosition(rb.position + moveVector);
        }

    }
    public IEnumerator ResetIsFallingAfterSeconds()
    {
        yield return new WaitForSeconds(2f);
        //agent.SetDestination(currentTarget);
        isFalling = false;
 
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
                GetComponent<L_Character>().FallBrick(); // Gọi hàm FallBrick từ AddBirck 
                StartCoroutine(ResetIsFallingAfterSeconds());// Bắt đầu đếm thời gian để character đứng dậy
            }
        }
    }
    public void StopMoveToForward()
    {
        moveSpeed = 0.1f;
    }
    public void ActiveSpeed()
    {
        moveSpeed = 6f;
    }
}
