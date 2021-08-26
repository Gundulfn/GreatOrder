using UnityEngine;
using TMPro;

public class GameOverInfoHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip moneyEarnClip, moneyLoseClip;

    private AudioSource aud;

    [SerializeField]
    private TextMeshProUGUI highestComboText, sliceCountText, moneyEarnedText;

    public void SetGameOverInfo()
    {
        int totalPoint = PointCalculator.GetTotalPoint();

        highestComboText.SetText("Highest Combo: x" + PointCalculator.GetHighestCombo().ToString());
        sliceCountText.SetText("Total Slice Count: " + PointCalculator.GetIngredientCount().ToString());
        moneyEarnedText.SetText("Money Earned: " + totalPoint.ToString());
        
        if(totalPoint > 0)
        {
            aud.clip = moneyEarnClip;
        }
        else if(totalPoint < 0)
        {
            aud.clip = moneyLoseClip;
        }

        aud.Play();
    }

    public void GameOver()
    {
        this.gameObject.SetActive(true);

        if(!aud)
        {
            aud = GetComponent<AudioSource>();
        }

        this.SetGameOverInfo();
    }
}