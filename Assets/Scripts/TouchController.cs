using UnityEngine;

public class TouchController : MonoBehaviour
{
    private IngredientSpawn ingredientSpawn;

    void Start()
    {
        ingredientSpawn = GetComponent<IngredientSpawn>();    
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began)
            {   
                ingredientSpawn.SpawnIngredient();
            }
        }
    }
}