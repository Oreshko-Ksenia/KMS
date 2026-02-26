using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

    public float moveSpeed = 5f; 
    public float rotationSpeed = 100f;

    void Update()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.E)) moveHorizontal = -1f;    
        if (Input.GetKey(KeyCode.Y)) moveHorizontal = 1f;  
        if (Input.GetKey(KeyCode.R)) moveVertical = 1f;    
        if (Input.GetKey(KeyCode.T)) moveVertical = -1f;  

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
