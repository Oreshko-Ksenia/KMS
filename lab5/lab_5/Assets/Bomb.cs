using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Terrain terrain;
    public GameObject explosionEffect;
    public AudioClip explosionSound;

    private void CreateExplosion(Vector3 position)
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, position, Quaternion.identity);
        }

        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, position);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CreateExplosion(collision.contacts[0].point);
    }
}
