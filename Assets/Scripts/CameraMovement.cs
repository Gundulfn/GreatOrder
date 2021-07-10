using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 targetPos = Vector3.one;

    [SerializeField]
    private GameOverInfoHandler gameOverInfoHandler;

    private float prevLength;
    public void SetTargetPos(Vector3 pos)
    {
        if (pos.z < -6)
        {
            targetPos = pos;
        }
        else
        {
            GameOver();
        }
    }

    void Update()
    {
        if (targetPos != Vector3.one)
        {
            if (prevLength == Vector3.MoveTowards(transform.position, targetPos, 5 * Time.deltaTime).sqrMagnitude)
            {
                GameOver();
                targetPos = Vector3.one;
            }
            else
            {
                prevLength = Vector3.MoveTowards(transform.position, targetPos, 5 * Time.deltaTime).sqrMagnitude;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, 5 * Time.deltaTime);
            }
        }
    }

    private void GameOver()
    {
        gameOverInfoHandler.gameObject.SetActive(true);
        gameOverInfoHandler.SetGameOverInfo();
    }
}