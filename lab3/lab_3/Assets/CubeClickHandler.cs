using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class CubeClickHandler : MonoBehaviour, IPointerClickHandler 
{
    public int forse = 100; 

    public void OnPointerClick(PointerEventData eventData) 
    {
        Vector3 target = eventData.pointerPressRaycast.worldPosition; 
        Vector3 collid = Camera.main.transform.position; 

        Vector3 distance = target - collid; 
        distance.Normalize(); 

        collid = distance * forse; 

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(collid, target);

        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        Color col1 = new Color(red, green, blue);

        gameObject.GetComponent<Renderer>().material.color = col1;
    }
}
