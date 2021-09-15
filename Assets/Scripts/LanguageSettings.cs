using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
using TMPro;

public class LanguageSettings : MonoBehaviour
{
    public static LanguageSettings instance;

    public static Locale currentLocale;
    public Locale defaultLocale;

    [SerializeField]
    private LanguageOptionList languageOptionList;

    [SerializeField]
    private GameObject languageSettingsUIObj;

    private TextMeshProUGUI text;

    void Start()
    {
        instance = this;

        if (!currentLocale)
        {
            currentLocale = defaultLocale;
        }
        
        text = GetComponentInChildren<TextMeshProUGUI>();

        EditButtonText();

        LocalizationSettings.SelectedLocale = currentLocale;

        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            string localeCode = LocalizationSettings.AvailableLocales.Locales[i].Identifier.Code;

            languageOptionList.SpawnOption(localeCode, i, languageSettingsUIObj);
        }
    }

    public void ChangeLanguage(int index)
    {
        if (LocalizationSettings.AvailableLocales.Locales[index])
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
            currentLocale = LocalizationSettings.SelectedLocale;
            EditButtonText();
        }
    }

    private void EditButtonText()
    {
        string systemLanguageCode = languageCodeDict[Application.systemLanguage];
        string currentLocaleCode = currentLocale.Identifier.Code;

        if (systemLanguageCode == currentLocaleCode)
        {
            text.SetText(
                languageTranslationDict[currentLocaleCode] + ": "
                + languageNameDict[currentLocaleCode]);
        }
        else
        {
            text.SetText(
                languageTranslationDict[currentLocaleCode] + "("
                + languageTranslationDict[systemLanguageCode] + "): "
                + languageNameDict[currentLocaleCode]);
        }
    }

    public static Dictionary<string, string> languageNameDict = new Dictionary<string, string>()
    {
        {"en", "English"},
        {"tr", "Türkçe"},
        {"az", "Azərbaycanca"},
        {"fr", "Français"},
        {"es", "Español"},
        {"ru", "Pусский"},
        {"de", "Deutsch"},
        {"id", "bahasa Indonesia"},
        {"pt", "Português"}
    };

    private Dictionary<string, string> languageTranslationDict = new Dictionary<string, string>()
    {
        {"en", "Language"},
        {"tr", "Dil"},
        {"az", "Dil"},
        {"fr", "Langue"},
        {"es", "Idioma"},
        {"ru", "Язык"},
        {"de", "Sprache"},
        {"id", "Bahasa"},
        {"pt", "Língua"}
    };

    private Dictionary<SystemLanguage, string> languageCodeDict = new Dictionary<SystemLanguage, string>()
    {
        {SystemLanguage.English, "en"},
        {SystemLanguage.Turkish, "tr"},
        {SystemLanguage.French, "fr"},
        {SystemLanguage.Spanish, "es"},
        {SystemLanguage.Russian, "ru"},
        {SystemLanguage.German, "de"},
        {SystemLanguage.Indonesian, "id"},
        {SystemLanguage.Portuguese, "pt"},
        {SystemLanguage.Unknown, "en"}
    };
}