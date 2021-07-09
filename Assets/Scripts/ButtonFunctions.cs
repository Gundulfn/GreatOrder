using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void StartGame()
    {
        Money.IncreaseMoneyAmount(200);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void OpenUI(GameObject uiObj)
    {
        uiObj.SetActive(true);
    }

    public void CloseUI(GameObject uiObj)
    {
        uiObj.SetActive(false);
    }

    public void PauseGame(GameObject uiObj)
    {
        OpenUI(uiObj);
        Time.timeScale = 0;
    }

    public void ResumeGame(GameObject uiObj)
    {
        CloseUI(uiObj);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("EntranceScene", LoadSceneMode.Single);
    }
}