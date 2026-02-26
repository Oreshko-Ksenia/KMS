using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 1f;
    public float rotSpeedBash = 1f;
    public float rotSpeedTank = 1f;
    public float minDistance = 2f;
    public float maxBashAngle = 90f;

    public Transform bash;
    public Transform stvol;
    public GameObject core;

    private bool canShoot = true;

    private RaycastHit hit;

    private Rigidbody rb;

    public float life = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * 10000f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            float distance = Vector3.Distance(other.transform.position, transform.position);

            Vector3 relativePos = other.transform.position - transform.position;

            Vector3 horizontalDir = new Vector3(relativePos.x, 0, relativePos.z);

            Vector3 bashDirection = Vector3.RotateTowards(bash.forward, horizontalDir, rotSpeedBash * Time.deltaTime, 0f);
            bash.rotation = Quaternion.LookRotation(bashDirection);

            float angle = Vector3.Angle(bash.forward, horizontalDir);

            if (angle < maxBashAngle)
            {
                if (angle >= 90f)
                {
                    Vector3 tankDirection = Vector3.RotateTowards(transform.forward, horizontalDir, rotSpeedTank * Time.deltaTime, 0f);
                    transform.rotation = Quaternion.LookRotation(tankDirection);
                }
            }

            stvol.rotation = Quaternion.LookRotation(bash.forward);

            if (angle < maxBashAngle && Physics.Raycast(bash.transform.position, bash.transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(bash.transform.position, bash.transform.TransformDirection(Vector3.forward) * 10, Color.red);

                if ((hit.transform.tag == "Goal") && canShoot)
                {
                    StartCoroutine(botshoot());
                }
            }

            if (distance < 20)
            {
                if (distance > minDistance)
                {
                    Vector3 targetDirection = new Vector3(relativePos.x, 0, relativePos.z);
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeedTank);

                    Vector3 targetPosition = Vector3.MoveTowards(transform.position, other.transform.position, moveSpeed * Time.deltaTime);
                    rb.MovePosition(targetPosition);
                }
            }
        }
    }

    private IEnumerator botshoot()
    {
        while (canShoot)
        {
            canShoot = false;
            yield return new WaitForSeconds(1f); 

            Vector3 forwardOfStvol = stvol.transform.position + stvol.transform.TransformDirection(Vector3.forward * 4f);
            GameObject newCore = Instantiate(core, forwardOfStvol, stvol.rotation);

            yield return new WaitForSeconds(3f);

            canShoot = true;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("core"))
        {
            if (--life < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
