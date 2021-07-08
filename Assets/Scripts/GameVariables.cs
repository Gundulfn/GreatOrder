using UnityEngine;

public class GameVariables: MonoBehaviour
{
    private static int money;
    private const int DEFAULT_MONEY_AMOUNT = 500;

    private static int ingredientVarietyCount;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        money = PlayerPrefs.GetInt("money", DEFAULT_MONEY_AMOUNT);
        ingredientVarietyCount = PlayerPrefs.GetInt("ingredientVar", 1);
    }

    public static int GetMoney()
    {
        return money;
    }

    public static int GetIngredientVar()
    {
        return ingredientVarietyCount;
    }

    public static void SetMoney(int value)
    {
        money = value;
        PlayerPrefs.SetInt("money", money);
    }
}