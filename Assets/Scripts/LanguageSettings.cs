using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSettings : MonoBehaviour
{
    public static LanguageSettings instance;

    [SerializeField]
    private Transform optionList;
    
    void Start()
    {
        instance = this;
    }

    public void ChangeLanguage(string langCode)
    {

    }
}
