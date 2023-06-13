using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLoad : MonoBehaviour
{
    public TMP_Text score;
    
    private void Start()
    {
        if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
        {
            score.text = "Best Score\n" + PlayerPrefs.GetInt("Best Score");
        }
        else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
        {
            score.text = "Рекорд\n" + PlayerPrefs.GetInt("Best Score");
        }
    }

    private void Update()
    {
        if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
        {
            score.text = "Best Score\n" + PlayerPrefs.GetInt("Best Score");
        }
        else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
        {
            score.text = "Рекорд\n" + PlayerPrefs.GetInt("Best Score");
        }
    }
}
