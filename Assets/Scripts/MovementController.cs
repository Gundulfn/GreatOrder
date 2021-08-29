using UnityEngine;

public class MovementController : MonoBehaviour
{
    private int moveSpeed = 1;
    private int direction = 1;
    private float currentSpeed;

    private bool canMove = true;

    [SerializeField]
    private bool editYPos;
    private float defaultYPos;

    void Start()
    {
        if(editYPos)
        {
            defaultYPos = transform.position.y;
        }
    }

    void Update()
    {
        if(canMove)
        {
            if (currentSpeed == 0)
            {
                currentSpeed = moveSpeed + PointCalculator.GetSpeedExtra();
            }

            transform.position = new Vector3(transform.position.x, defaultYPos, transform.position.z);

            if (Mathf.Abs(transform.position.x + currentSpeed * direction * Time.deltaTime) >= 1)
            {
                transform.position = new Vector3(direction, defaultYPos, transform.position.z);
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