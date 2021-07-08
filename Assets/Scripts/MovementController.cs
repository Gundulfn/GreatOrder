using UnityEngine;

public class MovementController : MonoBehaviour
{
    private int moveSpeed = 1;
    private int direction = 1;

    public float currentSpeed;

    void Update()
    {
        if (currentSpeed == 0)
        {
            currentSpeed = moveSpeed + PointCalculator.GetSpeedExtra();
        }

        transform.position = new Vector3(transform.position.x, 0, 0);

        if (Mathf.Abs(transform.position.x + currentSpeed * direction * Time.deltaTime) >= 1)
        {
            transform.position = new Vector3(direction, 0, 0);
            direction *= -1;
        }
        else
        {
            transform.position += transform.right * currentSpeed * direction * Time.deltaTime;
        }
    }
}