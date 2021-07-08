using UnityEngine;

public class Money
{
    private static bool isInitialized;

    public static void IncreaseMoneyAmount(int increasement)
    {
        int newMoney = GameVariables.GetMoney() + increasement;

        GameVariables.SetMoney(newMoney);
        MoneyStateBar.UpdateMoneyState();
    }

    public static void DecreaseMoneyAmount(int decreasement)
    {
        int newMoney;

        if (GameVariables.GetMoney() - decreasement < 0)
        {
            newMoney = 0;
        }
        else
        {
            newMoney = GameVariables.GetMoney() - decreasement;
        }

        GameVariables.SetMoney(newMoney);
        MoneyStateBar.UpdateMoneyState();
    }

    public static bool IsMoneyEnough(int price)
    {
        return GameVariables.GetMoney() >= price;
    }
}