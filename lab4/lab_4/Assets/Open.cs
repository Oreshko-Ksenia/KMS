using UnityEngine;

public class Open : MonoBehaviour
{
    public Transform LeftGate;
    public Transform RightGate;
    public float openAngle = 90f;
    public float closedAngle = 0f;
    public float openCloseSpeed = 2f;

    public Transform cubeToMove;
    public float cubeRotationSpeed = 50f;
    public float cubeFlySpeed = 1f;
    public Vector3 flyDirection = Vector3.right;

    private bool isRobotInTrigger = false;
    private bool isOpening = false;
    private bool isClosing = false;

    private void Start()
    {
        LeftGate.localRotation = Quaternion.Euler(0, closedAngle, 0);
        RightGate.localRotation = Quaternion.Euler(0, -closedAngle, 0);
    }

    private void Update()
    {
        if (isRobotInTrigger)
        {
            cubeToMove.Rotate(Vector3.up, cubeRotationSpeed * Time.deltaTime);
            cubeToMove.position += flyDirection * cubeFlySpeed * Time.deltaTime;
        }

        if (isOpening)
        {
            float newAngleLeft = Mathf.MoveTowardsAngle(LeftGate.localEulerAngles.y, openAngle, openCloseSpeed * Time.deltaTime);
            float newAngleRight = Mathf.MoveTowardsAngle(RightGate.localEulerAngles.y, -openAngle, openCloseSpeed * Time.deltaTime);

            LeftGate.localRotation = Quaternion.Euler(0, newAngleLeft, 0);
            RightGate.localRotation = Quaternion.Euler(0, newAngleRight, 0);

            if (Mathf.Approximately(newAngleLeft, openAngle) && Mathf.Approximately(newAngleRight, -openAngle))
            {
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            float newAngleLeft = Mathf.MoveTowardsAngle(LeftGate.localEulerAngles.y, closedAngle, openCloseSpeed * Time.deltaTime);
            float newAngleRight = Mathf.MoveTowardsAngle(RightGate.localEulerAngles.y, -closedAngle, openCloseSpeed * Time.deltaTime);

            LeftGate.localRotation = Quaternion.Euler(0, newAngleLeft, 0);
            RightGate.localRotation = Quaternion.Euler(0, newAngleRight, 0);

            if (Mathf.Approximately(newAngleLeft, closedAngle) && Mathf.Approximately(newAngleRight, -closedAngle))
            {
                isClosing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Robot")
        {
            isRobotInTrigger = true;
            isOpening = true;
            isClosing = false;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Robot")
        {
            isRobotInTrigger = false;
            isClosing = true;
            isOpening = false;
        }
    }
}