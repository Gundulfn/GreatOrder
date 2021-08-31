using UnityEngine;
using TMPro;

public class StatisticsUI: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highestNoiceComboText, roundPlayedText, highestEarnText;

    public void SetStatistics()
    {
        highestNoiceComboText.SetText(UITextData.highestNoiceCombo + Statistics.GetHighestNoiceCombo().ToString());
        roundPlayedText.SetText(UITextData.roundPlayed + Statistics.GetRoundPlayed().ToString());
        highestEarnText.SetText(UITextData.highestEarn + Statistics.GetHighestEarn().ToString());
    }
}