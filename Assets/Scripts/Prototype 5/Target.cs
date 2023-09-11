using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManagerS gameManager;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4;
    private float yRange = -4;

    public ParticleSystem particleEffect;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerS>();

        targetRB.AddForce(RandomForce(),  ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.UpdateLives(-1);
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(particleEffect, transform.position, particleEffect.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    Vector3 RandomSpawnPos()
    {
        float randomPos = Random.Range(-xRange, xRange);
        return new Vector3(randomPos, yRange, 0);
    }

    Vector3 RandomForce()
    {
        float randomForce = Random.Range(minSpeed, maxSpeed);
        return Vector3.up * randomForce;
    }


    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}