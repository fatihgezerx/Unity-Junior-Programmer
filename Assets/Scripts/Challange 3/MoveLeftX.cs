using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float moveLeftSpeed = 10f;
    private CharacterControllerX characterControllerScript;
    private float leftBound = -10f;

    // Start is called before the first frame update
    void Start()
    {
        characterControllerScript = GameObject.Find("Player").GetComponent<CharacterControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!characterControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveLeftSpeed);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
