using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIHandler : MonoBehaviour
{
    [SerializeField]
    private IngredientInfo[] datas;

    public GameObject infoUIPrefab;

    void Start()
    {
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
}