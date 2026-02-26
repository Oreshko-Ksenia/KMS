using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public Light Point;

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            Point.enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
        {
            Point.enabled = false;
        }
    }
}
