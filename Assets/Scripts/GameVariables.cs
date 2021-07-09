using UnityEngine;
using System.Linq;

public class GameVariables : MonoBehaviour
{
    private static int money;
    private const int DEFAULT_MONEY_AMOUNT = 500;

    private static int ingredientVarietyCount;
    private static string[] boughtIngredients = new string[50];

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        money = PlayerPrefs.GetInt("money", DEFAULT_MONEY_AMOUNT);

        Debug.Log(PlayerPrefs.GetString("boughtIngredients", ""));
        if (PlayerPrefs.GetString("boughtIngredients", "").Contains(";"))
        {
            boughtIngredients = PlayerPrefs.GetString("boughtIngredients", "").Split(';');
            ingredientVarietyCount = boughtIngredients.Length;

            for (int i = 0; i < ingredientVarietyCount; i++)
            {
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
        return ingredientVarietyCount;
    }

    public static void AddBoughtIngredient(string ingredientName)
    {
        boughtIngredients[ingredientVarietyCount] = ingredientName;
        ingredientVarietyCount++;

        IngredientPrefabData.AddIngredientPrefab(ingredientName);
        SaveBoughtIngredients();
    }

    public static bool IsIngredientBought(string ingredientName)
    {
        if (ingredientVarietyCount == 0)
        {
            return false;
        }

        return boughtIngredients.Contains(ingredientName);
    }

    private static void SaveBoughtIngredients()
    {
        string boughtIngredientsList = "";

        for (int i = 0; i < ingredientVarietyCount; i++)
        {
            boughtIngredientsList += boughtIngredients[i];

            if (i + 1 != ingredientVarietyCount)
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