using UnityEngine;

public class OrderMovement : MonoBehaviour
{
    private float ingredientThickness = .2f;
    private float targetY;

    public void Move(float ingredientThickness)
    {
        targetY = this.ingredientThickness + ingredientThickness; 
        transform.position -= transform.up * targetY;   
        this.ingredientThickness = ingredientThickness;
    }
}