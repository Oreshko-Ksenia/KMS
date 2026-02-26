using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    public Texture alternateTexture;

    public Texture[] collisionTextures;
    private int currentTextureIndex = 0; 

    public GameObject Cube1;

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.T) && Cube1 != null)
        {
            Cube1.GetComponent<Renderer>().material.mainTexture = alternateTexture;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.name == "Cube1" || col.gameObject.name == "Cube2") && collisionTextures.Length > 0)
        {
            col.gameObject.GetComponent<Renderer>().material.mainTexture = collisionTextures[currentTextureIndex];

            currentTextureIndex = (currentTextureIndex + 1) % collisionTextures.Length;
        }
    }
}
