using UnityEngine;
using TMPro;

public class MoneyStateBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyStateText;
    
    void Start()
    {
        UpdateMoneyState();
    }

    // Update is called once per frame
    public void UpdateMoneyState()
    {
        moneyStateText.SetText(GameVariables.GetMoney().ToString());
    }
}
