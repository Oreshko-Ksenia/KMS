using UnityEngine;

public class Core : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 5.0f;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            GetComponent<Renderer>().enabled = false;

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
