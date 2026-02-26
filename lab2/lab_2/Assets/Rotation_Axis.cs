using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Axis : MonoBehaviour {

    public Vector3 rotationAxis = new Vector3(1, 1, 0); 
    public float rotationAngle = 45f; 
    public float rotationSpeed = 1f; 

    void Start () {
        rotationAxis.Normalize();
    }
	
	void Update () {
        float angle = rotationSpeed * Time.deltaTime * rotationAngle;

        Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

        transform.rotation *= rotation;
    }
}
