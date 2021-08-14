using UnityEngine;
using TMPro;

public class MoneyStateBar : MonoBehaviour
{
    private static TextMeshProUGUI moneyStateText;

    private static Color defaultMoneyStateTextColor;

    void Awake()
    {
        moneyStateText = GetComponentInChildren<TextMeshProUGUI>();
        defaultMoneyStateTextColor = moneyStateText.color;
    }

    void Start()
    {
        UpdateMoneyState();
    }

    // Update is called once per frame
    public static void UpdateMoneyState()
    {
        if (moneyStateText)
        {
            if(GameVariables.GetMoney() >= 0)
            {
                moneyStateText.color = defaultMoneyStateTextColor;
            }
            else
            {
                moneyStateText.color = Color.red;
            }

            moneyStateText.SetText(GameVariables.GetMoney().ToString());
        }
    }
}