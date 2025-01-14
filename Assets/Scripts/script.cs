using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 6f;
    public float obstacleSpeed = 1f;
    public float laterobstacletime;
    public float laterobstaclespeed;
    public float timealive;

    [SerializeField] private Transform obstacleParent;
    private float timeUntilObstacleSpawn;

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;
        timealive += Time.deltaTime;
        laterobstacletime = obstacleSpawnTime / Mathf.Pow(timealive, 0.2f);
        laterobstaclespeed = obstacleSpeed * Mathf.Pow(timealive, 0.2f);

        if (timeUntilObstacleSpawn >= laterobstacletime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {

        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = obstacleParent;


        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * laterobstaclespeed;
    }

    public void ClearObstacle()
    {
        foreach (Transform child in obstacleParent)
            Destroy(child.gameObject);
    }

}