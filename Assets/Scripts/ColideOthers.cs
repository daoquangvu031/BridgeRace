using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ColideOthers : MonoBehaviour
{
    [SerializeField] private AnimationManage Anim;
    public NavMeshAgent agent;
    [SerializeField] private Character character;
    public IEnumerator ResetIsFallingAfterSeconds()
    {
        yield return new WaitForSeconds(2f);
        agent.enabled = true;
        character.isFalling = false;
        Bot bot = GetComponent<Bot>();
        if (bot != null)
        {
            Anim.ChangeAnim("Run");
        }
        else
        {
            Anim.ChangeAnim("Idle");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "character")
        {
            if (collision.gameObject.GetComponent<Character>().countBrick > GetComponent<Character>().countBrick)// Nếu số gạch của character kia lớn hơn số gạch của character này thì
            {
                Anim.ChangeAnim("Falling");
                // Ngã
                agent.velocity = Vector3.zero;
                agent.enabled = false;
                character.isFalling = true;
                GetComponent<AddBrick>().FallBrick(); // Gọi hàm FallBrick từ AddBirck 
                StartCoroutine(ResetIsFallingAfterSeconds());// Bắt đầu đếm thời gian để character đứng dậy
            }
        }
    }
}