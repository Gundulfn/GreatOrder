using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject breadObject;

    [SerializeField]
    private GameObject[] ingredients;

    [SerializeField]
    private OrderMovement orderMovement;

    private Transform placedIngredient;
    private MovementController spawnedIngredient;

    public void SpawnIngredient(int round = 1)
    {
        int randomInt = Random.Range(0, ingredients.Length);

        if (spawnedIngredient)
        {
            PointCalculator.CalculatePoint(spawnedIngredient.transform.position.x);
            PointCalculator.IncreaseIngredientCount();

            placedIngredient = spawnedIngredient.transform;
            Destroy(spawnedIngredient);
        }

        orderMovement.Move(ingredients[randomInt].transform.lossyScale.y / 2);

        GameObject obj = Instantiate(ingredients[randomInt]);
        obj.transform.parent = orderMovement.transform;
        obj.transform.position = new Vector3(-1, 0, 0);

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