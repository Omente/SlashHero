using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab, swingingObstaclePrefab, wolfPrefab, healthPrefab;
    [SerializeField] private GameObject[] rotatingObstaclePrefab;

    private int obstaclesPoolCount = 6;
    private float spikePos = -3.26f;
    private float wolfPos = -2.56f;
    private float rotatingObstacleMinY = -2.56f, rotatingObstacleMaxY = 3f;
    private float swingingObstacleMinY = 1.05f, swingingOnstacleMaxY = 4.87f;
    private float healthMinY = -3.15f, healthMaxY = 2.46f;
    private float minSpawnTimeObstacle = 2f, maxSpawnTimeObstacle = 3.5f;
    private float spawnTimeObstacle;
    private float obstacleSpawnXOoffset = 20f;
    private float minSpawnTimeHealth = 5f, maxSpawnTimeHealth = 7f;
    private float spawnTimeHealth;
    private float healthSpawnXOffset = 27f;
    private int obstacleTypeCount = 5;
    private int obstacleToSpawn;
    private Camera mainCamera;
    private Vector3 obstacleSpawnPos = Vector3.zero;
    private Vector3 healthSpawnPos = Vector3.zero;
    private GameObject newObstacle;
    private List<GameObject> objectPoolWolf = new List<GameObject>();
    private List<GameObject> objectPoolSpike = new List<GameObject>();
    private List<GameObject> objectPoolBlade = new List<GameObject>();
    private List<GameObject> objectPoolSwing = new List<GameObject>();
    private List<GameObject> objectPoolHealth = new List<GameObject>();

    private void Awake()
    {
        mainCamera = Camera.main;
        CreateObjectPool();
    }

    private void Start()
    {
        spawnTimeObstacle = Time.time + UnityEngine.Random.Range(minSpawnTimeObstacle, maxSpawnTimeObstacle);
        spawnTimeHealth = Time.time + UnityEngine.Random.Range(minSpawnTimeHealth, maxSpawnTimeHealth);
    }

    private void Update()
    {
        HandleObstacleSpawning();
        HandleHealthSpawning();
    }

    private void HandleObstacleSpawning()
    {
        if (Time.time < spawnTimeObstacle) return;
        spawnTimeObstacle = Time.time + UnityEngine.Random.Range(minSpawnTimeObstacle, maxSpawnTimeObstacle);
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        obstacleToSpawn = (int)UnityEngine.Random.Range(0f, obstacleTypeCount);
        obstacleSpawnPos.x = mainCamera.transform.position.x + obstacleSpawnXOoffset;
        switch (obstacleToSpawn)
        {
            case 0:
                foreach (var obstacle in objectPoolWolf)
                {
                    if (!obstacle.activeInHierarchy)
                    {
                        obstacle.SetActive(true);
                        obstacleSpawnPos.y = obstacle.transform.position.y;
                        obstacle.transform.position = obstacleSpawnPos;
                        break;
                    }
                }
                break;
            case 1:
                foreach (var obstacle in objectPoolSpike)
                {
                    if (!obstacle.activeInHierarchy)
                    {
                        obstacle.SetActive(true);
                        obstacleSpawnPos.y = obstacle.transform.position.y;
                        obstacle.transform.position = obstacleSpawnPos;
                        break;
                    }
                }
                break;
            case 2:
                foreach (var obstacle in objectPoolBlade)
                {
                    if (!obstacle.activeInHierarchy)
                    {
                        obstacle.SetActive(true);
                        obstacleSpawnPos.y = UnityEngine.Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                        obstacle.transform.position = obstacleSpawnPos;
                        break;
                    }
                }
                break;
            case 3:
                foreach (var obstacle in objectPoolSwing)
                {
                    if (!obstacle.activeInHierarchy)
                    {
                        obstacle.SetActive(true);
                        obstacleSpawnPos.y = UnityEngine.Random.Range(swingingObstacleMinY, swingingOnstacleMaxY);
                        obstacle.transform.position = obstacleSpawnPos;
                        break;
                    }
                }
                break;
            default:
                break;
        }
    }

    private void HandleHealthSpawning()
    {
        if (Time.time < spawnTimeHealth) return;
        spawnTimeHealth = Time.time + UnityEngine.Random.Range(minSpawnTimeHealth, maxSpawnTimeHealth);
        SpawnHealth();
    }

    private void SpawnHealth()
    {
        healthSpawnPos = Vector3.zero;
        healthSpawnPos.x = mainCamera.transform.position.x + healthSpawnXOffset;
        healthSpawnPos.y = UnityEngine.Random.Range(healthMinY, healthMaxY);

        foreach (var health in objectPoolHealth)
        {
            if(!health.activeInHierarchy)
            {
                health.SetActive(true);
                health.transform.position = healthSpawnPos;
                break;
            }
        }
    }

    private void CreateObjectPool()
    {
        for (int i = 0; i < obstacleTypeCount; i++)
        {
            for (int j = 0; j < obstaclesPoolCount; j++)
            {
                switch (i)
                {
                    case 0:
                        obstacleSpawnPos = Vector3.zero;
                        obstacleSpawnPos.y = wolfPos;
                        newObstacle = Instantiate(wolfPrefab);
                        newObstacle.transform.position = obstacleSpawnPos;
                        newObstacle.transform.SetParent(gameObject.transform.GetChild(i).transform);
                        newObstacle.SetActive(false);
                        objectPoolWolf.Add(newObstacle);
                        break;
                    case 1:
                        obstacleSpawnPos = Vector3.zero;
                        obstacleSpawnPos.y = spikePos;
                        newObstacle = Instantiate(spikePrefab);
                        newObstacle.transform.position = obstacleSpawnPos;
                        newObstacle.transform.SetParent(gameObject.transform.GetChild(i).transform);
                        newObstacle.SetActive(false);
                        objectPoolSpike.Add(newObstacle);
                        break;
                    case 2:
                        obstacleSpawnPos = Vector3.zero;
                        obstacleSpawnPos.y = UnityEngine.Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                        newObstacle = Instantiate(rotatingObstaclePrefab[UnityEngine.Random.Range(0, rotatingObstaclePrefab.Length)]);
                        newObstacle.transform.position = obstacleSpawnPos;
                        newObstacle.transform.SetParent(gameObject.transform.GetChild(i).transform);
                        newObstacle.SetActive(false);
                        objectPoolBlade.Add(newObstacle);
                        break;
                    case 3:
                        obstacleSpawnPos = Vector3.zero;
                        obstacleSpawnPos.y = UnityEngine.Random.Range(swingingObstacleMinY, swingingOnstacleMaxY);
                        newObstacle = Instantiate(swingingObstaclePrefab);
                        newObstacle.transform.position = obstacleSpawnPos;
                        newObstacle.transform.SetParent(gameObject.transform.GetChild(i).transform);
                        newObstacle.SetActive(false);
                        objectPoolSwing.Add(newObstacle);
                        break;
                    case 4:
                        newObstacle = Instantiate(healthPrefab);
                        newObstacle.transform.position = healthSpawnPos;
                        newObstacle.transform.SetParent(gameObject.transform.GetChild(i).transform);
                        newObstacle.SetActive(false);
                        objectPoolHealth.Add(newObstacle);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}