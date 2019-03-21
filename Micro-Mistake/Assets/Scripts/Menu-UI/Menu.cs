using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("MenuMusicPlayer").GetComponent<MenuMusic>().PlayMusic();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
