using UnityEngine;
using System.Collections.Generic;

public class LanguageOptionList: MonoBehaviour
{
    [SerializeField]
    private GameObject langOptionPrefab;

    public void SpawnOption(string code, int id, GameObject obj)
    {
        GameObject langOption = Instantiate(langOptionPrefab);
        langOption.transform.SetParent(transform, false);
        
        string value;
        if(LanguageSettings.languageNameDict.TryGetValue(code, out value))
        {
            value += "(" + code + ")";
            langOption.GetComponent<LanguageOption>().SetLangCode(value, id, obj);
        }
        else
        {
            langOption.GetComponent<LanguageOption>().SetLangCode(code, id, obj);
        }
    }
}