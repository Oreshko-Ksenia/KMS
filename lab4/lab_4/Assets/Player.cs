using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 5f;      
    public float rotationSpeed = 100f;  

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
