using UnityEngine;

public class MovementController : MonoBehaviour
{
    private int moveSpeed = 1;
    private int direction = 1;

    public float currentSpeed;

    void Update()
    {
        currentSpeed = moveSpeed * direction * Time.deltaTime;

        transform.position = new Vector2(transform.position.x, 0);
        
        if(Mathf.Abs(transform.position.x + moveSpeed * direction * Time.deltaTime) >= 1)
        {
            transform.position = new Vector2(direction, 0);
            direction *= -1;
        }
        else
        {
            transform.position += transform.right * moveSpeed * direction * Time.deltaTime;
        }
    }
}