using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour
{

    public float moveSpeed = 5f; 
    public float rotationSpeed = 2f; 

    private float verticalRotation = 0f; 

    void Start()
    {
      
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        transform.Translate(horizontalInput * moveSpeed * Time.deltaTime, 0, verticalInput * moveSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed; 
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed; 

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, 0, 90); 

        transform.Rotate(0, mouseX, 0); 
        transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, 0);
    }
}