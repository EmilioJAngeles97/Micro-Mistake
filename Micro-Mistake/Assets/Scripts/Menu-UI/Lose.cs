using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private void Start()
    {
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
