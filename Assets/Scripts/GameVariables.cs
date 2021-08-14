using UnityEngine;
using System.Collections.Generic;

public class GameVariables : MonoBehaviour
{
    private static int money;
    private const int DEFAULT_MONEY_AMOUNT = 500;

    private const string DEFAULT_INGREDIENTS = "Patty;Lettuce;Tomato";
    private static List<string> boughtIngredients = new List<string>();

    private static bool reset;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        money = PlayerPrefs.GetInt("money", DEFAULT_MONEY_AMOUNT);

        string[] values = PlayerPrefs.GetString("boughtIngredients", DEFAULT_INGREDIENTS).Split(';');

        for (int i = 0; i < values.Length; i++)
        {
            boughtIngredients.Add(values[i]);
            IngredientPrefabData.AddIngredientPrefab(boughtIngredients[i]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            reset = !reset;
            Debug.Log(reset);
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
        Debug.Log(boughtIngredients.Count + " " + PlayerPrefs.GetString("boughtIngredients", DEFAULT_INGREDIENTS));
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

        if (boughtIngredientsList == "")
        {
            boughtIngredientsList = DEFAULT_INGREDIENTS;
        }

        PlayerPrefs.SetString("boughtIngredients", boughtIngredientsList);
    }

    void OnApplicationQuit()
    {
        if (reset)
        {
            PlayerPrefs.DeleteAll();
        }
        else
        {
            SaveBoughtIngredients();
            PlayerPrefs.SetInt("money", money);
        }
    }
}