using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameOverVideScript : MonoBehaviour
{
    public RawImage image;
    public VideoPlayer videoPlayerScirpt;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayerScirpt.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.2f);
        while (!videoPlayerScirpt.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        image.texture = videoPlayerScirpt.texture;
        videoPlayerScirpt.Play();
    }
}
