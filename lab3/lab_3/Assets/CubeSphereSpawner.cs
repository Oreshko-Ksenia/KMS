using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphereSpawner : MonoBehaviour {

    public GameObject spherePrefab;

    public float spawnHeight = 5f;

    public float tiltAngle = 90f;

    public float tiltSpeed = 30f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MeshCollider planeCollider = GetComponent<MeshCollider>();
            if (planeCollider == null) return;

            Bounds bounds = planeCollider.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float z = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 spawnPosition = new Vector3(x, spawnHeight, z);
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = spawnPosition;

            newCube.AddComponent<Rigidbody>();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MeshCollider planeCollider = GetComponent<MeshCollider>();
            if (planeCollider == null) return;

            Bounds bounds = planeCollider.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float z = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 spawnPosition = new Vector3(x, spawnHeight, z);
            GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

            newSphere.AddComponent<Rigidbody>();
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, tiltAngle), tiltSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, 0f), tiltSpeed * Time.deltaTime);
        }
    }

}
