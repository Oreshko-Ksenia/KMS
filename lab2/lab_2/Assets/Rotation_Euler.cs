using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Euler : MonoBehaviour {

    public float rotationSpeedX = 50.0f; 
    public float rotationSpeedZ = 30.0f;  

    void Start () {
		
	}
	
	void Update () {

        transform.Rotate(rotationSpeedX * Time.deltaTime, 0, 0); 
        transform.Rotate(0, 0, rotationSpeedZ * Time.deltaTime, Space.Self);  
    }
}
