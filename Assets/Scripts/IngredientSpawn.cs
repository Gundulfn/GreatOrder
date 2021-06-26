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
        obj.transform.position = new Vector2(-1, 0);

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
        if (placedIngredient)
        {
            Instantiate(breadObject, new Vector2(0, placedIngredient.position.y + placedIngredient.lossyScale.y / 2 + breadObject.transform.lossyScale.y / 2), Quaternion.identity);
        }
        else
        {
            orderMovement.Reset();
            Instantiate(breadObject, new Vector2(0, breadObject.transform.lossyScale.y), Quaternion.identity);
        }

        orderMovement.StopMovement();

        Destroy(spawnedIngredient.gameObject);
    }
}