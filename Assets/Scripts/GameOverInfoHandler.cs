using UnityEngine;
using TMPro;

public class GameOverInfoHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyEarnedText, highestComboText;

    public void SetGameOverInfo()
    {
        moneyEarnedText.SetText(PointCalculator.GetTotalPoint().ToString());
        highestComboText.SetText(PointCalculator.GetHighestCombo().ToString());
    }
}
