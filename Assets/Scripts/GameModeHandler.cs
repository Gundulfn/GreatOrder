using UnityEngine;
using TMPro;

public class GameModeHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI topText;

    [SerializeField]
    private GameObject gameControllerObj;

    [SerializeField]
    private GameOverInfoHandler gameOverInfoHandler;

    //Race against time
    private const float DEFAULT_TIME = 5;
    private float currentTime = DEFAULT_TIME;

    private static bool hasGameStarted;
    
    void Update()
    {
        if (hasGameStarted)
        {
            if (currentTime > 1)
            {
                currentTime -= Time.deltaTime;
                topText.SetText((int)currentTime + " seconds left");
            }
            else
            {
                topText.SetText("Time's up");

                gameControllerObj.GetComponent<IngredientSpawn>().DestroyMovingIngredient();
                gameControllerObj.SetActive(false);
                
                Reset();
            }
        }
        else
        {
            topText.SetText("Press to start");
        }
    }

    public static void StartGame()
    {
        hasGameStarted = true;
        Time.timeScale = 1;
    }

    public static void Reset()
    {
        hasGameStarted = false;
    }
}