using UnityEngine;

public class GameVariables
{
    private static int money;
    private static int ingredientVarietyCount;

    public static int GetMoney()
    {
        return money;
    }

    public static int GetIngredientVar()
    {
        return ingredientVarietyCount;
    }

    public static void Initialize()
    {
        money = PlayerPrefs.GetInt("money", 0);
        ingredientVarietyCount = PlayerPrefs.GetInt("ingredientVar", 1);
    }
}