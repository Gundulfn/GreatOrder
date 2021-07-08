using UnityEngine;

public class PointCalculator
{
    private static int posPoint;
    private static int placedIngredientCount;
    private static int noicePointCount;

    private const float NOICE_LIMIT = .1f;
    private const float BAD_LIMIT = .5f;

    private const int NOICE_POINT = 30;
    private const int GOOD_POINT = 10;
    private const int BAD_POINT = -5;

    public static void CalculatePoint(float ingredientPos)
    {
        ingredientPos = Mathf.Abs(ingredientPos);
        
        if(ingredientPos <= NOICE_LIMIT)
        {
            posPoint += NOICE_POINT;
            noicePointCount++;
        }
        else if(ingredientPos >= BAD_LIMIT)
        {
            posPoint += BAD_POINT;
            noicePointCount = 0;
        }
        else
        {
            posPoint += GOOD_POINT;
            noicePointCount = 0;
        }
    }

    public static int GetTotalPoint()
    {
        int totalPoint = posPoint + GameVariables.GetIngredientVar() * placedIngredientCount;

        //Reset point variables
        placedIngredientCount = 0;
        noicePointCount = 0;
        posPoint = 0;

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
}