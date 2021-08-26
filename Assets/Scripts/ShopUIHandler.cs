using UnityEngine;

public class ShopUIHandler : MonoBehaviour
{
    public static ShopUIHandler instance;

    [SerializeField]
    private IngredientInfo[] datas;

    public GameObject infoUIPrefab;

    [SerializeField]
    private Animation notificationAnim;

    [SerializeField]
    private AudioSource aud;

    void Start()
    {
        instance = this;

        for (int i = 0; i < datas.Length; i++)
        {
            if (!GameVariables.IsIngredientBought(datas[i].ingredientName))
            {                
                GameObject infoUI = Instantiate(infoUIPrefab);
                infoUI.transform.SetParent(transform, false);
                infoUI.GetComponent<IngredientInfoUI>().SetData(datas[i]);
            }
        }
    }

    public void PlayNotification()
    {
        notificationAnim.Play();
        notificationAnim.GetComponent<AudioSource>().Play();
    }

    public void PlayBuySound()
    {
        aud.Play();
    }
}