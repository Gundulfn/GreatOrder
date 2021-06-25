using UnityEngine;
using TMPro;

public class TouchController : MonoBehaviour
{
    private IngredientSpawn ingredientSpawn;
    public TextMeshProUGUI text;

    void Start()
    {
        ingredientSpawn = GetComponent<IngredientSpawn>();    
    }

    // Update is called once per frame
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