using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Text gameWinTimeText;
    public float endMinutes;
    public float endSeconds;

    Timer timerScript;
    // Start is called before the first frame update
    void Start()
    {
        endMinutes = (int)(PlayerPrefs.GetFloat("min"));
        endSeconds = (int)(PlayerPrefs.GetFloat("sec"));
        gameWinTimeText = GameObject.Find("GameTimeText").GetComponent<Text>();
        gameWinTimeText.text = endMinutes.ToString("00") + ":" + endSeconds.ToString("00");
        PlayerPrefs.SetFloat("min", 0f);
        PlayerPrefs.SetFloat("sec", 0f);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
