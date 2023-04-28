using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bot : MonoBehaviour
{
    private int brickCount = 0;
    private Transform balo;
    private Transform dot;
    [SerializeField] private InventorBrick ivb;
    public GameObject cube;
    public NavMeshAgent agent;
    public Character character;
    public Color currentColor;
    public List<GameObject> brickList = new List<GameObject>();
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public AddBrick addBrick;

    Color[] colors;
    private Transform nextTargetPoint;
    private Transform targetPoint;

    void Start()
    {
        // Tìm tất cả các gạch trong khu vực và thêm vào danh sách
        GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject brick in allBricks)
        {
            brickList.Add(brick);
        }
        colors = ivb.colors;
        /*foreach (Color color in colors)
        {
            Debug.Log(color.ToString());
        }*/
    }
    void Update()
    {
        GoToTargetPoint();
    }

    public void GoToTargetPoint()
    {
        brickCount = character.countBrick;
        // Tìm kiếm đối tượng vật thể gần nhất
        if (nextTargetPoint == null || brickCount <= 0)
        {
            nextTargetPoint = GetNearestBrick(brickList).transform;
        }
        targetPoint = nextTargetPoint;

        // Nếu có đối tượng vật thể gần nhất, di chuyển đến nó
        if (targetPoint != null)
        {
            if (agent.enabled == true)
                agent.SetDestination(targetPoint.position);
            // Nếu bot đến gần đối tượng vật thể
            if (Vector3.Distance(transform.position, targetPoint.position) < 1f)
            {
                if (targetPoint.CompareTag("Brick"))
                {
                    // _listBrickTarget.Remove(targetPoint.gameObject);    // tạm thời loại bỏ brick target ra khỏi brick

                    if (3 >= brickCount)
                    {
                        nextTargetPoint = GetNearestBrick(brickList).transform;
                    }
                    else
                    {
                        nextTargetPoint = cube.transform;
                    }
                }
            }
        }
    }
    private GameObject GetNearestBrick(List<GameObject> bricks)
    {
        // Tìm viên gạch gần nhất với bot
        GameObject nearestBrick = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject brick in bricks)
        {
            if (brick.GetComponent<MeshRenderer>().material.color == currentColor && brick.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(brick.transform.position, transform.position);
                if (distance < minDistance)
                {
                    nearestBrick = brick;
                    minDistance = distance;
                }
            }
        }
        return nearestBrick;
    }
}
