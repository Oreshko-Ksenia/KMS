using UnityEngine;

public class LightingTrigger : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("__Tank"))
        {
            if (gameObject.name == "RedTrigger" && redLight != null)
            {
                redLight.intensity = 10f;
            }
            else if (gameObject.name == "BlueTrigger" && blueLight != null)
            {
                blueLight.intensity = 10f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("__Tank"))
        {
            if (gameObject.name == "RedTrigger" && redLight != null)
            {
                redLight.intensity = 0f;
            }
            else if (gameObject.name == "BlueTrigger" && blueLight != null)
            {
                blueLight.intensity = 0f;
            }
        }
    }
}
