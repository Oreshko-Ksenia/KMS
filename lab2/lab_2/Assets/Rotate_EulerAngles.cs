using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_EulerAngles : MonoBehaviour {

    public float rotationSpeedX = 45.0f; 
    public float rotationSpeedZ = 45.0f;

    void Start () {
		
	}
	
	void Update () {

        Vector3 currentAngles = transform.eulerAngles;

        currentAngles.x += Time.deltaTime * rotationSpeedX;
        currentAngles.z += Time.deltaTime * rotationSpeedZ;

        transform.eulerAngles = currentAngles;
    }
}
