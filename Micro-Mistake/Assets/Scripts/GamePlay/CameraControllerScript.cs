using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public Camera poolCamera;
    public Camera firstPerson;
    public Camera thirdPerson;

    public bool inPool;

    // Start is called before the first frame update
    void Start()
    {
        firstPerson.enabled = true;
        thirdPerson.enabled = false;
        poolCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inPool == true)
        {
            firstPerson.enabled = false;
            thirdPerson.enabled = false;
            poolCamera.enabled = true;
        }
    }

}
