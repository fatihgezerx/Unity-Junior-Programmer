using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private Rigidbody vehicleRB;

    public int inputID;

    private float verticalInput; //Forward&Backward
    private float horizontalInput; //Right&Left

    [SerializeField]
    private float moveSpeed = 10.0f;
    public float turnSpeed = 5.0f;

    //[SerializeField] GameObject centerOfMass;

    //Start is called before the first frame update
    void Start()
    {
        vehicleRB = GetComponent<Rigidbody>();
        //vehicleRB.centerOfMass = centerOfMass.transform.position;
    }

    //Update is called once per frame
    void Update()
    {
        //Get the user's vertical input
        verticalInput = Input.GetAxis("Vertical" + inputID);
        //Get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);

        vehicleRB.AddRelativeForce(Vector3.forward * moveSpeed * verticalInput);
        //Turn the vehicle right/left
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput); //Vector3.up = transform.Rotate(0, 1, 0);
    }
}