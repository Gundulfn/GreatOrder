using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject secondChanceUIObj;

    private const float TARGET_SIZE = 15;
    private const float MOVEMENT_START_THRESHOLD = -6;

    private bool isCameraMoving;
    private Vector3 targetPos;

    public void MoveCamera(float value)
    {
        if (value < MOVEMENT_START_THRESHOLD)
        {
            targetPos = new Vector3(0, value, 0);
            isCameraMoving = true;
        }
        else
        {
            secondChanceUIObj.SetActive(true);
        }
    }

    void Update()
    {
        if (isCameraMoving)
        {
            if (Camera.main.orthographicSize < TARGET_SIZE || Vector3.Distance(transform.position, targetPos) > .5f)
            {
                Camera.main.orthographicSize += Time.deltaTime * 5;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, 5 * Time.deltaTime);
            }
            else
            {
                secondChanceUIObj.SetActive(true);
                isCameraMoving = false;
            }
        }
    }
}