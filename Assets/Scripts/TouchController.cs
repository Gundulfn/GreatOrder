using UnityEngine;
using UnityEngine.EventSystems;

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
            Touch firstTouch = Input.GetTouch(0);

            int id = firstTouch.fingerId;

                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    return;
                }

            if(firstTouch.phase == TouchPhase.Began)
            {   
                ingredientSpawn.SpawnIngredient();
            }
        }
    }
}