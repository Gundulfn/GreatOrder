using UnityEngine;
using TMPro;

public class MoneyStateBar : MonoBehaviour
{
    private static TextMeshProUGUI moneyStateText;
    
    void Start()
    {
        moneyStateText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateMoneyState();
    }

    // Update is called once per frame
    public static void UpdateMoneyState()
    {
        moneyStateText.SetText(GameVariables.GetMoney().ToString());
    }
}
