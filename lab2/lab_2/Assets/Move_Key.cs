using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Key : MonoBehaviour {

    public float moveSpeed = 5f; 
    void Start () {
		
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
    }
}
