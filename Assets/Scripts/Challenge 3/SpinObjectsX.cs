using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjectsX : MonoBehaviour
{
    public float spinSpeed = 20.0f;
    private Vector3 spinRotation = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinRotation * Time.deltaTime * spinSpeed);
    }
}
