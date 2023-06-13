// Language_changer.cs
using UnityEngine;

public class Language_changer : MonoBehaviour
{
    public void Set_RU()
    {
        // сохраняем пару ключ-значение
        PlayerPrefs.SetString("GameLanguage", "RU");
        Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
        // выведем сведетельство того, что игра увидела смену языка
        Debug.Log("Language changed to RUSSIAN");
    }
    public void Set_EN()
    {
        PlayerPrefs.SetString("GameLanguage", "EN");
        Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
        Debug.Log("Language changed to ENGLISH");
    }
}
