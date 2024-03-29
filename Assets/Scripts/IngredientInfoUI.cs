using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientInfoUI : MonoBehaviour
{
    private IngredientInfo data;

    [SerializeField]
    private Image img;

    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyIngredient);
    }

    public void SetData(IngredientInfo data)
    {
        //Check if ingredient has bought, if it's bought set interactable off
        this.data = data; 
        img.sprite = data.ingredientImg;
        text.SetText(data.ingredientName + " - " + data.price.ToString() + " " + UITextData.credits);
    }

    public void BuyIngredient()
    {
        if(Money.IsMoneyEnough(data.price))
        {
            Money.DecreaseMoneyAmount(data.price);
            GameVariables.AddBoughtIngredient(data.ingredientName);
            ShopUIHandler.instance.PlayBuySound();

            Destroy(this.gameObject);
        }
        else
        {
            ShopUIHandler.instance.PlayNotification();
        }
    }
}