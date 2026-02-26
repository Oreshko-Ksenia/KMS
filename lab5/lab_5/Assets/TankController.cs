using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;               
    public float rotationSpeed = 100f;         
    public Transform turret;                   
    public float turretRotationSpeed = 50f; 
    public Transform gun;                    
    public float gunTiltSpeed = 30f;  
    public float minGunAngle = -10f; 
    public float maxGunAngle = 45f; 

    private Rigidbody rb;              
    private AudioSource audioSource;  
    private bool isMoving = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        Vector3 movement = transform.forward * move;
        rb.MovePosition(rb.position + movement);
        Quaternion rotation = Quaternion.Euler(0, rotate, 0);
        rb.MoveRotation(rb.rotation * rotation);

        if (Mathf.Abs(move) > 0.01f || Mathf.Abs(rotate) > 0.01f)
        {
            if (!isMoving)
            {
                audioSource.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                audioSource.Stop();
                isMoving = false;
            }
        }

        if (turret != null)
        {
            float turretRotate = Input.GetAxis("Mouse X") * turretRotationSpeed * Time.deltaTime;
            turret.Rotate(0, turretRotate, 0);
        }

        if (gun != null)
        {
            float gunTilt = Input.GetAxis("Mouse Y") * gunTiltSpeed * Time.deltaTime;
            Vector3 currentGunRotation = gun.localEulerAngles;
            if (currentGunRotation.x >= 180) currentGunRotation.x -= 360;
            currentGunRotation.x = Mathf.Clamp(currentGunRotation.x + gunTilt, minGunAngle, maxGunAngle);
            gun.localEulerAngles = new Vector3(currentGunRotation.x, currentGunRotation.y, currentGunRotation.z);
        }
    }
}
