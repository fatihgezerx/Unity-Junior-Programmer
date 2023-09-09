using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVehicle : MonoBehaviour
{
    public GameObject playerVehicle;
    private Vector3 offset = new Vector3(0, 4, -6); //Camera Position

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Using LateUpdate method, because it will update it after Update() method
    void LateUpdate()
    {
        //Offset the camera behind the player by adding to the player's position
        transform.position = playerVehicle.transform.position + offset;
    }
}
