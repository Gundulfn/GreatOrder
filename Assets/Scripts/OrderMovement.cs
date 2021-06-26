using UnityEngine;

public class OrderMovement : MonoBehaviour
{
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
            transform.position = new Vector2(0, targetY);
            isMoving = false;
        }

        if(isFirstMove)
        {
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
            Vector2 movement = Vector2.MoveTowards(transform.position, new Vector2(0, targetY), 5 * Time.deltaTime);

            if (movement.y <= targetY)
            {
                transform.position = new Vector2(0, targetY);
            }
            else
            {
                transform.position = movement;
            }
        }
    }

    public void AddOrderPart(GameObject obj)
    {

    }
}