using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPosition : MonoBehaviour {
    public float speedX = 1.0f;
    public float speedY = 10.0f;
    public float speedZ = 5.0f;

    public float timeToDisappearX = 2.0f;
    public float timeToDisappearY = 2.0f;
    public float timeToDisappearZ = 2.0f;

    private float screenWidth;
    private float screenHeight;

    void Start () {

        screenWidth = Camera.main.orthographicSize * Camera.main.aspect * 2;
        screenHeight = Camera.main.orthographicSize * 2;

        speedX = screenWidth / timeToDisappearX;
        speedY = screenHeight / timeToDisappearY;
        speedZ = screenWidth / timeToDisappearZ; 
    }
	

	void Update () {
        Vector3 position = transform.position;

        position.x += speedX * Time.deltaTime;   
        position.y += speedY * Time.deltaTime;   
        position.z += speedZ * Time.deltaTime;   

        transform.position = position;
    }
}
