using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject breadObject;

    [SerializeField]
    private OrderMovement orderMovement;

    private Transform placedIngredient;
    private MovementController spawnedIngredient;

    public void SpawnIngredient(int round = 1)
    {
        GameObject ingredientPrefab = IngredientPrefabData.GetRandomIngredient();

        if (spawnedIngredient)
        {
            PointCalculator.CalculatePoint(spawnedIngredient.transform.position.x);
            PointCalculator.IncreaseIngredientCount();

            placedIngredient = spawnedIngredient.transform;
            Destroy(spawnedIngredient);
        }

        orderMovement.Move(ingredientPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y);

        GameObject obj = Instantiate(ingredientPrefab);
        
        //BUG: Ingredients don't touch each other when fast-clicking 
        obj.transform.parent = orderMovement.transform;
        obj.transform.position = new Vector3(-1, 0, obj.transform.position.z + orderMovement.transform.position.z);

        spawnedIngredient = obj.GetComponent<MovementController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnIngredient();
        }
    }

    public void DestroyMovingIngredient()
    {
        Vector3 spawnPos;

        float breadObjectY = breadObject.GetComponent<SpriteRenderer>().bounds.size.y;
        
        if (placedIngredient)
        {
            float placedIngredientY = placedIngredient.GetComponent<SpriteRenderer>().bounds.size.y;

            spawnPos = new Vector3(0,
                                   placedIngredient.position.y + (breadObjectY + placedIngredientY) / 2,
                                   breadObject.transform.position.z + orderMovement.transform.position.z);
        }
        else
        {
            orderMovement.Reset();
            spawnPos = new Vector3(0, (breadObjectY + orderMovement.defaultThickness) / 2, orderMovement.transform.position.z);
        }

        GameObject breadObj = Instantiate(breadObject, spawnPos, Quaternion.identity);
        breadObj.transform.parent = orderMovement.transform;

        orderMovement.StopMovement();
        Destroy(spawnedIngredient.gameObject);
    }
}