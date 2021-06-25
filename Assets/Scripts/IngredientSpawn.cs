using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ingredients;
    
    [SerializeField]
    private OrderMovement orderMovement;

    private MovementController spawnedIngredient;
    
    private float prevY = 0;
    private int spawnCount = 0;

    public void SpawnIngredient()
    {
        int randomInt = Random.Range(0, ingredients.Length);
        
        if(spawnedIngredient)
        {
            Destroy(spawnedIngredient);
        }

        orderMovement.Move(ingredients[randomInt].transform.lossyScale.y / 2);
        
        GameObject obj = Instantiate(ingredients[randomInt], new Vector2(-1, 0), Quaternion.identity);
        obj.transform.parent = orderMovement.transform;
        
        spawnedIngredient = obj.GetComponent<MovementController>();
        
        spawnCount++;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnIngredient();
        }
    }
}