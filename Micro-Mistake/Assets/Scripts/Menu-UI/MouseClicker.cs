using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    public GameObject mouseClickedImage;
    private IEnumerator mouseClick;
    // Start is called before the first frame update
    void Start()
    {
        mouseClick = MouseClick();
        StartCoroutine(mouseClick);
    }

    IEnumerator MouseClick()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(1f);
            if (mouseClickedImage.activeInHierarchy == false)
            {
                mouseClickedImage.SetActive(true);
            }
            else if (mouseClickedImage.activeInHierarchy == true)
            {
                mouseClickedImage.SetActive(false);
            }
        }
    }
}
