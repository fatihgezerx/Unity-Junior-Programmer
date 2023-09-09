using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 10.0f;
    public float startDelay = 2.5f;
    public float repeatInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //This method will cull the function (inside of it) will repeat over a period of time
        InvokeRepeating("SpawnRandomAnimal", startDelay, repeatInterval); //(FunctionName, StartTime, RepeatTime)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Very first Function in this jurney!
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length); //Choose animals randomly from array (animalPrefabs.Length)
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 20);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
