using UnityEngine;

public class Point : MonoBehaviour
{
    public Light Point1;
    public Light Point2;
    public Light Point3;
    public Transform Cylinder;
    public float maxIntensity = 2f;
    public float intensitySpeed = 1f;
    public float rotationSpeed = 30f;

    private void Start()
    {
        Point1.intensity = 0f;
        Point2.intensity = 0f;
        Point3.intensity = 0f;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.name == "Robot")
        {
            Point1.intensity = Mathf.MoveTowards(Point1.intensity, maxIntensity, intensitySpeed * Time.deltaTime);
            Point2.intensity = Mathf.MoveTowards(Point2.intensity, maxIntensity, intensitySpeed * Time.deltaTime);
            Point3.intensity = Mathf.MoveTowards(Point3.intensity, maxIntensity, intensitySpeed * Time.deltaTime);

            Cylinder.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Robot")
        {
            Point1.intensity = 0f;
            Point2.intensity = 0f;
            Point3.intensity = 0f;
        }
    }
}