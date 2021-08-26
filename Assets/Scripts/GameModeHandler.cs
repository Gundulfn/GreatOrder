using UnityEngine;
using TMPro;

public class GameModeHandler : MonoBehaviour
{
    public static GameModeHandler instance;

    [SerializeField]
    private TextMeshProUGUI topText;

    [SerializeField]
    private AdController adController;

    [SerializeField]
    private GameObject gameControllerObj, secondChanceUIObj, centerLineObj;

    //GameMode: Race against time
    private const float DEFAULT_TIME = 45;
    private const float EXTRA_TIME = 10;
    private float currentTime;

    private bool hasGameStarted;

    private IngredientSpawn ingredientSpawn;
    
    void Start()
    {
        instance = this;

        ingredientSpawn = gameControllerObj.GetComponent<IngredientSpawn>();
        currentTime = DEFAULT_TIME;
    }

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

                if(!adController.isRewardedAdPlayed)
                {
                    ingredientSpawn.StopSpawning();
                    secondChanceUIObj.SetActive(true);
                }
                else
                {
                    ingredientSpawn.EndSpawning();
                }

                gameControllerObj.SetActive(false);
                centerLineObj.SetActive(false);

                hasGameStarted = false;
            }
        }
        else
        {
            topText.SetText("Press to start");
        }
    }

    // For extra time ad
    public void AddExtraTime()
	{
        currentTime = EXTRA_TIME;
        hasGameStarted = true;

        gameControllerObj.SetActive(true);
        centerLineObj.SetActive(true);

        ingredientSpawn.ContinueSpawning();
	}

    public void RejectExtraTime()
    {
        ingredientSpawn.EndSpawning();
    }

    public void StartGame()
    {
        hasGameStarted = true;
        Time.timeScale = 1;
    }
}