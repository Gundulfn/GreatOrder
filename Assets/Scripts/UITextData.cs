using UnityEngine;

public class UITextData: MonoBehaviour
{
    public static string highestNoiceCombo, roundPlayed, highestEarn, credits;
    public static string noiceStreak, totalSliceCount, moneyEarned, pressToStart, timeUp;

    public void SetTextData(string data)
    {
        string[] dataElements = data.Split(';');

        highestNoiceCombo = dataElements[0];
        roundPlayed = dataElements[1];
        highestEarn = dataElements[2]; 
        credits = dataElements[3];
        noiceStreak = dataElements[4];
        totalSliceCount = dataElements[5];
        moneyEarned = dataElements[6];
        pressToStart = dataElements[7];
        timeUp = dataElements[8];
    }
}