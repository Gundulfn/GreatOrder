using UnityEngine;
using TMPro;

public class LanguageOption: MonoBehaviour
{
    private string langText;
    private int langId;

    private TextMeshProUGUI text;
    private GameObject languageSettingUIObj;
    
    public void SetLangCode(string textValue, int id, GameObject obj)
    {
        langText = textValue;
        langId = id;
        languageSettingUIObj = obj;

        text = GetComponentInChildren<TextMeshProUGUI>();        
        text.SetText(langText);
    }

    public void OnLanguageOptionClick()
    {
        LanguageSettings.instance.ChangeLanguage(langId);
        languageSettingUIObj.SetActive(false);
    }
}