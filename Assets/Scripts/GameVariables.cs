using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GameVariables : MonoBehaviour
{
    private static int money;
    private const int DEFAULT_MONEY_AMOUNT = 500;
    private static List<string> boughtIngredients = new List<string>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        money = PlayerPrefs.GetInt("money", DEFAULT_MONEY_AMOUNT);

        if (PlayerPrefs.GetString("boughtIngredients", "") != "")
        {
            string[] values = PlayerPrefs.GetString("boughtIngredients", "").Split(';');

            for (int i = 0; i < values.Length; i++)
            {
                boughtIngredients.Add(values[i]);
                IngredientPrefabData.AddIngredientPrefab(boughtIngredients[i]);
            }
        }
    }

    public static int GetMoney()
    {
        return money;
    }

    public static void SetMoney(int value)
    {
        money = value;
        PlayerPrefs.SetInt("money", money);
    }

    public static int GetIngredientVar()
    {
        return boughtIngredients.Count;
    }

    public static void AddBoughtIngredient(string ingredientName)
    {
        boughtIngredients.Add(ingredientName);

        IngredientPrefabData.AddIngredientPrefab(ingredientName);
        SaveBoughtIngredients();
    }

    public static bool IsIngredientBought(string ingredientName)
    {
        if (boughtIngredients.Count == 0)
        {
            return false;
        }

        return boughtIngredients.Contains(ingredientName);
    }

    private static void SaveBoughtIngredients()
    {
        string boughtIngredientsList = "";

        for (int i = 0; i < boughtIngredients.Count; i++)
        {
            boughtIngredientsList += boughtIngredients[i];

            if (i + 1 != boughtIngredients.Count)
            {
                boughtIngredientsList += ";";
            }
        }

        PlayerPrefs.SetString("boughtIngredients", boughtIngredientsList);
    }

    void OnApplicationQuit()
    {
        SaveBoughtIngredients();
        PlayerPrefs.SetInt("money", money);
    }
}