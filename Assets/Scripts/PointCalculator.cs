using UnityEngine;

public class PointCalculator
{
    private static int posPoint, placedIngredientCount;
    private static int noicePointCount, highestNoiceCount;

    private const float NOICE_LIMIT = .1f;
    private const float BAD_LIMIT = .5f;

    private const int NOICE_POINT = 30;
    private const int GOOD_POINT = 10;
    private const int BAD_POINT = -5;

    public const string NOICE_TYPE = "noice";
    public const string GOOD_TYPE = "good";
    public const string BAD_TYPE = "bad";

    public static string CalculatePoint(float ingredientPos)
    {
        ingredientPos = Mathf.Abs(ingredientPos);
        
        if(ingredientPos <= NOICE_LIMIT)
        {
            posPoint += NOICE_POINT;
            noicePointCount++;

            if(noicePointCount > highestNoiceCount)
            {
                highestNoiceCount = noicePointCount;
            }

            return NOICE_TYPE;
        }
        else if(ingredientPos >= BAD_LIMIT)
        {
            posPoint += BAD_POINT;
            noicePointCount = 0;

            return BAD_TYPE;
        }
        else
        {
            posPoint += GOOD_POINT;
            noicePointCount = 0;

            return GOOD_TYPE;
        }
    }

    public static int GetTotalPoint()
    {
        int totalPoint = posPoint + GameVariables.GetIngredientVar() * placedIngredientCount;

        //Reset point variables
        posPoint = 0;
        placedIngredientCount = 0;
        noicePointCount = 0;

        Money.IncreaseMoneyAmount(totalPoint);
        return totalPoint;
    }

    public static void IncreaseIngredientCount()
    {
        placedIngredientCount++;
    }
    
    public static int GetSpeedExtra()
    {
        return noicePointCount;
    }

    public static int GetIngredientCount()
    {
        return placedIngredientCount;
    }

    public static int GetHighestCombo()
    {
        int value = highestNoiceCount;
        highestNoiceCount = 0;

        return value;
    }
}