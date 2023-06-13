using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text Score;
    public static int score = 0;

    void Update()
    {
        if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "English")
        {
            Score.text =  "Score: " + score.ToString();
        }
        else if (Lean.Localization.LeanLocalization.GetFirstCurrentLanguage() == "Russian")
        {
            Score.text =  "Очки: " + score.ToString();
        }
        if (Main.s_health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void ScoreCount()
    {
        score += 1;
    }
    
    public void BlackScoreCount()
    {
        score += 50;
    }
    
}
