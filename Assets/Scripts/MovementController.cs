using UnityEngine;

public class MovementController : MonoBehaviour
{
    private int moveSpeed = 1;
    private int direction = 1;
    private float currentSpeed;

    private bool canMove = true;

    void Update()
    {
        if(canMove)
        {
            if (currentSpeed == 0)
            {
                currentSpeed = moveSpeed + PointCalculator.GetSpeedExtra();
            }

            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

            if (Mathf.Abs(transform.position.x + currentSpeed * direction * Time.deltaTime) >= 1)
            {
                transform.position = new Vector3(direction, 0, transform.position.z);
                direction *= -1;
            }
            else
            {
                transform.position += transform.right * currentSpeed * direction * Time.deltaTime;
            }
        }
    }

    public void Stop()
    {
        canMove = false;
    }

    public void Move()
    {
        canMove = true;
    }
}