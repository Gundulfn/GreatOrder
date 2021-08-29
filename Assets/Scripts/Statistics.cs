using UnityEngine;

public class Statistics: MonoBehaviour
{
    private static int highestNoiceCombo, roundPlayed, highestEarn;
    private static bool isInitialized;

    void Awake()
    {
        if(!isInitialized)
        {
            highestNoiceCombo = PlayerPrefs.GetInt("highestNoiceCombo", 0);
            roundPlayed = PlayerPrefs.GetInt("roundPlayed", 0);
            highestEarn = PlayerPrefs.GetInt("highestEarn", 0);

            isInitialized = true;
        }
    }

    public static void SetHighestNoiceCombo(int value)
    {
        if(value > highestNoiceCombo)
        {
            highestNoiceCombo = value;
        }
    }

    public static void IncreaseRoundPlayed()
    {
        roundPlayed++;
    }

    public static void SetHighestEarn(int value)
    {
        if(value > highestEarn)
        {
            highestEarn = value;
        }
    }

    public static int GetHighestNoiceCombo()
    {
        return highestNoiceCombo;
    }

    public static int GetRoundPlayed()
    {
        return roundPlayed;
    }

    public static int GetHighestEarn()
    {
        return highestEarn;
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("highestNoiceCombo", highestNoiceCombo);
        PlayerPrefs.SetInt("roundPlayed", roundPlayed);
        PlayerPrefs.SetInt("highestEarn", highestEarn);
    }
}