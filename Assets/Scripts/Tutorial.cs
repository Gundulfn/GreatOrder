using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private const int TUTORIAL_PLAYED_VALUE = 1;

    void Start()
    {
        if(PlayerPrefs.GetInt("isTutorialPlayed", 0) == TUTORIAL_PLAYED_VALUE)
        {
            Destroy(this.gameObject);
        }
    }

    public void EndTutorial()
    {
        PlayerPrefs.SetInt("isTutorialPlayed", TUTORIAL_PLAYED_VALUE);
        Destroy(this.gameObject);
    }
}