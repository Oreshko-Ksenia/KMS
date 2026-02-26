using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quaternion : MonoBehaviour {

    private Quaternion initialRotation; 
    private float angleX = 0f;         
    private float angleZ = 0f;          
    public float rotationSpeed = 45.0f; 

    void Start () {

        initialRotation = transform.rotation;
    }
	
	void Update () {
        angleX += rotationSpeed * Time.deltaTime;
        angleZ += rotationSpeed * Time.deltaTime;

        Quaternion rotationX = Quaternion.AngleAxis(angleX, Vector3.right);

        Quaternion rotationZ = Quaternion.AngleAxis(angleZ, Vector3.forward);

        transform.rotation = initialRotation * rotationX * rotationZ;
    }
}
