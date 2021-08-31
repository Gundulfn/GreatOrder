using UnityEngine;

public class LanguageOption: MonoBehaviour
{
    private string langCode;

    public void SetLangCode(string value)
    {
        langCode = value;
    }

    public void OnLanguageOptionClick()
    {
        LanguageSettings.instance.ChangeLanguage(langCode);
    }
}