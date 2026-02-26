using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour {

    public Light SpotLight;  
    public float rotationSpeed = 30f; 

    void OnTriggerStay(Collider col)
    {
        if (col.name == "Player")
        {
            SpotLight.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
