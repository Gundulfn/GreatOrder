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

        orderMovement.Move(ingredientPrefab.transform.lossyScale.y / 2);

        GameObject obj = Instantiate(ingredientPrefab);
        obj.transform.parent = orderMovement.transform;
        obj.transform.position = new Vector3(-1, 0, orderMovement.transform.position.z);

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

        if (placedIngredient)
        {
            spawnPos = new Vector3(0, 
                                   placedIngredient.position.y + placedIngredient.lossyScale.y / 2 + breadObject.transform.lossyScale.y / 2,
                                   orderMovement.transform.position.z);
        }
        else
        {
            orderMovement.Reset();
            spawnPos = new Vector3(0, breadObject.transform.lossyScale.y, orderMovement.transform.position.z);
        }

        GameObject breadObj = Instantiate(breadObject, spawnPos, Quaternion.identity);
        breadObj.transform.parent = orderMovement.transform;
        
        orderMovement.StopMovement();
        Destroy(spawnedIngredient.gameObject);
    }
}