using UnityEngine;
using TMPro;

public class GameOverInfoHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highestComboText, sliceCountText, moneyEarnedText;

    public void SetGameOverInfo()
    {
        highestComboText.SetText("Highest Combo: x" + PointCalculator.GetHighestCombo().ToString());
        sliceCountText.SetText("Total Slice Count: " + PointCalculator.GetIngredientCount().ToString());
        moneyEarnedText.SetText("Money Earned: " + PointCalculator.GetTotalPoint().ToString());
    }

    public void GameOver()
    {
        this.gameObject.SetActive(true);
        this.SetGameOverInfo();
    }
}