using UnityEngine;

public class TankGun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public AudioClip shotSound;
    public Transform firePoint;
    public float shotVolume = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Vector3 spawnPosition = firePoint.position;
        Quaternion spawnRotation = firePoint.rotation;

        Instantiate(projectilePrefab, spawnPosition, spawnRotation);

        if (shotSound != null)
        {
            AudioSource.PlayClipAtPoint(shotSound, spawnPosition, shotVolume);
        }
    }
}
