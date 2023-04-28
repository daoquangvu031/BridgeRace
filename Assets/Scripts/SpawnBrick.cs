using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrick : MonoBehaviour
{
    public GameObject Brick;
    public float ReSpawnTime = 2f;
    public float timer = 0f;
    public Color[] colors = {Color.red, Color.blue, Color.green, Color.yellow};
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ReSpawnTime)
        {
            SpawnBrickAtRandomPosition();
            timer = 0f;
        }
    }
    void SpawnBrickAtRandomPosition()
    {
        Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 5f, Random.Range(-5f, 5f));
        StartCoroutine(Spawn(randomPos));
    }

    public IEnumerator Spawn(Vector3 position)
    {
        // (timer < ReSpawnTime)
        //{
        //    timer += Time.deltaTime;
        //    yield return null;
        //}
        //timer = 0;
        GameObject go = Instantiate(Brick);
        go.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, 4)];
        go.transform.position = position;
        yield return null;
    }
}