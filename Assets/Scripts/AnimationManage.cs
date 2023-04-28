using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManage : MonoBehaviour
{
    private Animator Anim;
    private string currentAnimName;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

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
}
