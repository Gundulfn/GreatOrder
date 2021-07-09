using UnityEngine;
using System.Collections.Generic;

public class IngredientPrefabData : MonoBehaviour
{
    private static List<GameObject> boughtIngredientPrefabs = new List<GameObject>();

    //Get and add bought ingredient prefab from Resources
    public static void AddIngredientPrefab(string ingredientName)
    {
        string path = "Prefabs/" + ingredientName;
        GameObject ingredientPrefab = (GameObject)Resources.Load(path);
        
        Debug.Log(ingredientName);
        Debug.Log(ingredientPrefab.name);
        boughtIngredientPrefabs.Add(ingredientPrefab);
    }

    public static GameObject GetRandomIngredient()
    {
        int randomInt = Random.Range(0, boughtIngredientPrefabs.Count);

        return boughtIngredientPrefabs[randomInt];
    }
}