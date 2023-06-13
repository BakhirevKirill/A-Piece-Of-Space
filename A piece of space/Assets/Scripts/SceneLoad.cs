using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Scenes(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
