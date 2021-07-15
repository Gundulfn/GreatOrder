using UnityEngine;

public class OrderMovement : MonoBehaviour
{
    [SerializeField]
    private CameraMovement cameraMovement;
    public float ingredientThickness;
    private float targetY;

    private bool isMoving;
    private bool isFirstMove = true;

    public void Move(float ingredientThickness)
    {
        if (isMoving)
        {
            transform.position = new Vector3(0, targetY, transform.position.z);
            isMoving = false;
        }

        if (isFirstMove)
        {
            GameModeHandler.StartGame();

            
            isFirstMove = false;
        }
        
        transform.Translate(new Vector2(0, -ingredientThickness));
    }

    void Update()
    {
        isMoving = transform.position.y > targetY;

        if (isMoving)
        {
            Vector3 movement = Vector3.MoveTowards(transform.position, new Vector3(0, targetY, transform.position.z), 5 * Time.deltaTime);

            if (movement.y <= targetY)
            {
                transform.position = new Vector3(0, targetY, transform.position.z);
            }
            else
            {
                transform.position = movement;
            }
        }
    }

    public void StopMovement()
    {
        cameraMovement.SetTargetPos(new Vector3(0, transform.position.y / 2, transform.position.y));
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
    }
}