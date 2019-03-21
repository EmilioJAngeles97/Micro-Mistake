using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource menuAudioSource;
    public static MenuMusic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        menuAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log("audio playing: " + menuAudioSource.isPlaying);
    }

    public void PlayMusic()
    {
        if (menuAudioSource.isPlaying == true)
        {
            return;
        } else if(menuAudioSource.isPlaying == false)
        menuAudioSource.Play();
    }

    public void StopMusic()
    {
        menuAudioSource.Stop();
    }
}
