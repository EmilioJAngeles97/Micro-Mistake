using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBarScript : MonoBehaviour
{
    public GameObject sizeBar;
    public Transform sizeBarTransform;

    PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        sizeBarTransform = sizeBar.transform;
        //SetSize(0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        SetSize(playerScript.sizeLerp);
    }

    public void SetSize(float sizeNormalized)
    {
        sizeBarTransform.localScale = new Vector3(sizeNormalized, 1f);
    }
}
