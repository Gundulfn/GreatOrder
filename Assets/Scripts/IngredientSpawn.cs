using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject breadObject;

    [SerializeField]
    private OrderMovement orderMovement;

    [SerializeField]
    private GameObject badNotificationObj, goodNotificationObj, noiceNotificationObj;

    private Transform placedIngredient;
    private MovementController spawnedIngredient;

    private GameObject breadObj;

    public void SpawnIngredient(bool moveOrder = true)
    {
        if(orderMovement.isMoving)
        {
            return;
        }

        GameObject ingredientPrefab = IngredientPrefabData.GetRandomIngredient();

        if (spawnedIngredient)
        {
            string pointType = PointCalculator.CalculatePoint(spawnedIngredient.transform.position.x);

            placedIngredient = spawnedIngredient.transform;
            Destroy(spawnedIngredient);

            badNotificationObj.SetActive(false);
            goodNotificationObj.SetActive(false);
            noiceNotificationObj.SetActive(false);

            if(pointType == PointCalculator.NOICE_TYPE)
            {
                noiceNotificationObj.SetActive(true);
            }
            else if(pointType == PointCalculator.GOOD_TYPE)
            {
                goodNotificationObj.SetActive(true);
            }
            else
            {
                badNotificationObj.SetActive(true);
            }
        }

        if(moveOrder)
        {
            orderMovement.Move(ingredientPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y);
        }

        GameObject obj = Instantiate(ingredientPrefab);
        
        obj.transform.parent = orderMovement.transform;
        obj.transform.position = new Vector3(-1, 0, obj.transform.position.z + orderMovement.transform.position.z);

        spawnedIngredient = obj.GetComponent<MovementController>();
    }

    public void StopSpawning()
    {
        spawnedIngredient.Stop();
    }

    public void ContinueSpawning()
    {
        spawnedIngredient.Move();
    }
    
    public void EndSpawning()
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

        breadObj = Instantiate(breadObject, spawnPos, Quaternion.identity);
        breadObj.transform.parent = orderMovement.transform;

        orderMovement.StopMovement();
        Destroy(spawnedIngredient.gameObject);
    }
}