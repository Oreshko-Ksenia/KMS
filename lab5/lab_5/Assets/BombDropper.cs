using UnityEngine;
using System.Collections;


public class BombDropper : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombHeight = 15f;
    public float spread = 20f;
    public float timeToDisappear = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBombs();
        }
    }

    void DropBombs()
    {
        Vector3 tankPosition = transform.position;
        for (int i = 0; i < 3; i++)  
        {
            float randomX = Random.Range(-spread, spread);
            float randomZ = Random.Range(-spread, spread);
            Vector3 dropPosition = new Vector3(tankPosition.x + randomX, tankPosition.y + bombHeight, tankPosition.z + randomZ);

            GameObject bomb = Instantiate(bombPrefab, dropPosition, Quaternion.identity);
            StartCoroutine(DestroyBomb(bomb));
        }
    }

    IEnumerator DestroyBomb(GameObject bomb)
    {
        yield return new WaitForSeconds(timeToDisappear);
        Destroy(bomb);
    }
}
