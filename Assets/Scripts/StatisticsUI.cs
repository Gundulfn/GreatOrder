using UnityEngine;
using TMPro;

public class StatisticsUI: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highestNoiceComboText, roundPlayedText, highestEarnText;

    private const string HIGHEST_NOICE_COMBO_TEXT = "Highest Noice Combo: x";
    private const string ROUND_PLAYED_TEXT = "Round Played: ";
    private const string HIGHEST_EARN_TEXT = "Highest Earn: ";

    public void SetStatistics()
    {
        highestNoiceComboText.SetText(HIGHEST_NOICE_COMBO_TEXT + Statistics.GetHighestNoiceCombo().ToString());
        roundPlayedText.SetText(ROUND_PLAYED_TEXT + Statistics.GetRoundPlayed().ToString());
        highestEarnText.SetText(HIGHEST_EARN_TEXT + Statistics.GetHighestEarn().ToString());
    }
}