using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public int inputID;

    private float verticalInput; //Forward&Backward
    private float horizontalInput; //Right&Left

    public float moveSpeed = 10.0f;
    public float turnSpeed = 5.0f;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //Get the user's vertical input
        verticalInput = Input.GetAxis("Vertical" + inputID);
        //Get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        //Move the vehicle forward/back
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput); //Vector3.forward = transform.Translate(0, 0, 1);
        //Turn the vehicle right/left
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput); //Vector3.up = transform.Rotate(0, 1, 0);
    }
}