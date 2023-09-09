using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveLeftSpeed = 10f;
    private CharacterController characterController;
    private float leftBound = -7.5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.gameOver == false) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveLeftSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}