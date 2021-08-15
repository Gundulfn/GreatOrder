using UnityEngine;

public class OrderMovement : MonoBehaviour
{
    [SerializeField]
    private CameraMovement cameraMovement;

    public float defaultThickness
    {
        get;
        private set;
    }

    private float ingredientThickness;
    private float targetY;

    private bool isMoving;
    private bool isFirstMove = true;

    void Start()
    {
        defaultThickness = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        ingredientThickness = defaultThickness;
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
            GameModeHandler.instance.StartGame();
            isFirstMove = false;
        }

        targetY = transform.position.y + -(this.ingredientThickness + ingredientThickness) / 2;
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
        cameraMovement.MoveCamera(transform.position.y / 2);
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, transform.position.z);
    }
}