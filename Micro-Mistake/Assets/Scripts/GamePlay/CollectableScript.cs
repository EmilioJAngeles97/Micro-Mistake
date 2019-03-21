using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableScript : MonoBehaviour
{
    public bool collidingWithFlower;
    public bool collidingWithHammer;
    public bool collidingWithFlask;
    public bool collidingWithAcorn;

    public bool collidingWithObject;
    public string nameOfObject;

    CollectablesController collectablesManagerScript;

    AudioSource collectableAudioSource;
    public AudioClip collectedSound;

    // Start is called before the first frame update
    void Start()
    {
        collectablesManagerScript = GameObject.FindWithTag("GameManager").GetComponent<CollectablesController>();
        collectableAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collidingWithObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                if (nameOfObject == "Flower")
                {
                    collectablesManagerScript.obtainedFlower = true;
                }

                if (nameOfObject == "Hammer")
                {
                    collectablesManagerScript.obtainedHammer = true;
                }

                if (nameOfObject == "Acorn")
                {
                    collectablesManagerScript.obtainedAcorn = true;
                }

                if (nameOfObject == "Flask")
                {
                    collectablesManagerScript.obtainedFlask = true;
                }
                collectablesManagerScript.collidingWithAnObject = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            collectableAudioSource.PlayOneShot(collectedSound);
            collectablesManagerScript.collidingWithAnObject = true;
            collidingWithObject = true;
            nameOfObject = this.gameObject.name;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            collectablesManagerScript.collidingWithAnObject = false;
            collidingWithObject = false;
            nameOfObject = null;
        }
    }
}
