using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    //private Animator Animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private AnimationManage Anim;
    [SerializeField] private float Speed;
    [SerializeField] private Character character;
    private CharacterController characterController;
    public Transform player;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {   
        if (character.isFalling == true)
        {
            return;
        }
        rb.velocity = new Vector3(joystick.Horizontal * Speed, rb.velocity.y, joystick.Vertical * Speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            //Run
            Anim.ChangeAnim("Run");
            transform.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x,0,rb.velocity.z));

        }
        else
            Anim.ChangeAnim("Idle");
    }
}
