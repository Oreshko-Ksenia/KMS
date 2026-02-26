using UnityEngine;

public class WallRotate : MonoBehaviour
{
    public Transform wall;         
    public float rotationSpeed = 50f; 

    private bool isTankInside = false; 

    void Update()
    {
        if (isTankInside && wall != null)
        {
            wall.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("__Tank"))
        {
            isTankInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("__Tank"))
        {
            isTankInside = false;
        }
    }
}
