using UnityEngine;
using System.Linq;

public class GameVariables : MonoBehaviour
{
    private static int money;
    private const int DEFAULT_MONEY_AMOUNT = 500;

    private static int ingredientVarietyCount;
    private static string[] boughtIngredients;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        money = PlayerPrefs.GetInt("money", DEFAULT_MONEY_AMOUNT);

        boughtIngredients = PlayerPrefs.GetString("boughtIngredients", "Cheese;Meat;").Split(';');

        ingredientVarietyCount = boughtIngredients.Length;
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
        boughtIngredients[boughtIngredients.Length - 1] = ingredientName;
        SaveBoughtIngredients();
    }

    public static bool IsIngredientBought(string ingredientName)
    {
        Debug.Log(ingredientName + " " + boughtIngredients);
        return boughtIngredients.Contains(ingredientName);
    }

    void OnApplicationQuit()
    {
        SaveBoughtIngredients();
        PlayerPrefs.SetInt("money", money);
    }

    private static void SaveBoughtIngredients()
    {
        string boughtIngredientsList = "";

        for (int i = 0; i < boughtIngredients.Length; i++)
        {
            boughtIngredientsList += boughtIngredients[i] + ";";
        }

        PlayerPrefs.SetString("boughtIngredients", boughtIngredientsList);
    }
}