using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameOverInfoHandler gameOverInfoHandler;
    
    private const float TARGET_SIZE = 15;
    private const float MOVEMENT_START_THRESHOLD = -5;

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
            StartCoroutine(EndGameWithDelay());
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
                gameOverInfoHandler.GameOver();
                isCameraMoving = false;
            }
        }
    }

    private IEnumerator EndGameWithDelay()
    {
        yield return new WaitForSeconds(2);
        gameOverInfoHandler.GameOver();
    }
}