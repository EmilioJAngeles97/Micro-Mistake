using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManShrinkScript : MonoBehaviour
{
    public float startSize;
    public float endSize;
    public Vector3 scaleDecreaser;
    public float scaleDecreaserAmount;

    // Start is called before the first frame update
    void Start()
    {
        startSize = 4f;
        endSize = 0.7f;
        scaleDecreaserAmount = -0.01f;
        gameObject.transform.localScale = new Vector3(startSize, startSize, startSize);
        scaleDecreaser = new Vector3(scaleDecreaserAmount, scaleDecreaserAmount, scaleDecreaserAmount);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += scaleDecreaser;

        if (gameObject.transform.localScale.x <= 0.7f)
        {
            gameObject.transform.localScale = new Vector3(startSize, startSize, startSize);
        }
    }
}
