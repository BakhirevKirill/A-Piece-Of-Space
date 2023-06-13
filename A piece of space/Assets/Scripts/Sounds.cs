using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;

    public Image MusicButton;
    public bool isOn;
    public AudioSource ad;

    private void Start()
    {
        isOn = true;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("sounds") == 1)
        {
            MusicButton.GetComponent<Image>().sprite = onMusic;
            ad.enabled = true;
            isOn = true;
        }
        else if (PlayerPrefs.GetInt("sounds") == 0)
        {
            MusicButton.GetComponent<Image>().sprite = offMusic;
            ad.enabled = false;
            isOn = false;
        }
    }

    public void offSound()
    {
        if (!isOn)
        {
            PlayerPrefs.SetInt("sounds", 1);
        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("sounds", 0);
        }
    }
}
