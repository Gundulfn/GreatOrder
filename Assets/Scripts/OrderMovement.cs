using UnityEngine;

public class OrderMovement : MonoBehaviour
{
    [SerializeField]
    private CameraMovement cameraMovement;
    private float ingredientThickness;
    private float targetY;

    private bool isMoving;
    private bool isFirstMove = true;

    void Start()
    {
        ingredientThickness = transform.lossyScale.y / 2;
    }

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

            transform.Translate(new Vector2(0, -ingredientThickness));
            isFirstMove = false;
        }
        else
        {
            targetY = transform.position.y - (this.ingredientThickness + ingredientThickness);
        }

        this.ingredientThickness = ingredientThickness;
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