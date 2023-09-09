using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerr : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float startDelay = 2f;
    public float repeatRate = 2f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (characterController.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length); //Choose obstacles randomly from array (obstaclePrefabs.Length)
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}