using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player Movement Vars
    private Rigidbody rb;
    private Animator playerAnimations;
    public float speed;
    public float clockwise;
    public float counterClockwise;
    public bool canMove;
    public float pickupTime;
    public float pickupTimer;
    public float xMove;
    public float yMove;
    public float xLook;

    // Player Size Vars
    private Vector3 scaleDecreaser;
    public float scaleAmount;
    public float startSize;
    public float endSize;
    public float sizeLerp;

    // Map Vars
    public bool atGopherEntrance;
    public bool atGopherExit;
    public GameObject gopherHoleExitSpawn;
    public GameObject gopherHoleSpawn;
    private Vector3 gopherSpawnPoint;
    private Vector3 gopherExitPoint;
    public GameObject canEnter;
    public GameObject cannotEnter;
    public GameObject canExit;

    // Camera
    public Camera poolCamera;
    public Camera thirdPerson;

    // PowerUp
    public float powerUpTimer;
    public float powerUpTime;
    public bool powerUpTriggered;

    // Sounds
    AudioSource playerAudioSource;
    public AudioClip walkSound;
    public AudioClip powerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("MenuMusicPlayer").GetComponent<MenuMusic>().StopMusic();
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Sound", 0.0f, 0.6f);
        speed = 10f;
        clockwise = 100f;
        counterClockwise = -100f;

        playerAnimations = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        pickupTime = 0;
        pickupTimer = 3;

        scaleAmount = -0.002f;
        scaleDecreaser = new Vector3(scaleAmount, scaleAmount, scaleAmount);

        startSize = 4f;
        endSize = 0.7f;

        atGopherEntrance = false;
        atGopherExit = false;

        gopherSpawnPoint = new Vector3(gopherHoleSpawn.transform.position.x - 3f, gopherHoleSpawn.transform.position.y + 2f, gopherHoleSpawn.transform.position.z);
        gopherExitPoint = new Vector3(gopherHoleExitSpawn.transform.position.x, gopherHoleExitSpawn.transform.position.y + 2f, gopherHoleExitSpawn.transform.position.z + 4f);
        gameObject.transform.localScale = new Vector3(startSize, startSize, startSize);

        powerUpTriggered = false;
        powerUpTime = 0f;
        powerUpTimer = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        xLook = Input.GetAxis("Mouse X");

        if (canMove == true)
        {
            Movement();
            PickUp();
        }
        
        PickUpTimer();
        MapCheck();

        if (powerUpTime <= 0)
        {
            ShrinkPlayer();
        }
        else
        {
            powerUpTime -= Time.deltaTime;
        }
    }

    public void Movement()
    {
        
        transform.position += transform.TransformDirection(Vector3.forward * yMove * speed * Time.deltaTime);
        transform.position += transform.TransformDirection(Vector3.right * xMove * speed * Time.deltaTime);
        playerAnimations.SetFloat("xMove", xMove);
        playerAnimations.SetFloat("yMove", yMove);
        transform.Rotate(0, xLook * Time.deltaTime * clockwise , 0);
        //if (canMove == true)
        //{
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        rb.position += transform.forward * Time.deltaTime * speed;
        //        playerAnimations.SetBool("WalkingForward", true);
        //    }
        //    else if (Input.GetKey(KeyCode.S))
        //    {
        //        rb.position -= transform.forward * Time.deltaTime * speed;
        //        playerAnimations.SetBool("WalkingBackward", true);
        //    }
        //    else if (Input.GetKey(KeyCode.A))
        //    {
        //        rb.position -= transform.right * Time.deltaTime * speed;
        //        playerAnimations.SetBool("WalkingLeft", true);
        //    }
        //    else if (Input.GetKey(KeyCode.D))
        //    {
        //        rb.position += transform.right * Time.deltaTime * speed;
        //        playerAnimations.SetBool("WalkingRight", true);
        //    }
        //    else
        //    {
        //        playerAnimations.SetBool("WalkingForward", false);
        //        playerAnimations.SetBool("WalkingBackward", false);
        //        playerAnimations.SetBool("WalkingRight", false);
        //        playerAnimations.SetBool("WalkingLeft", false);
        //    }

        //    // Rotation
        //    if (Input.GetKey(KeyCode.RightArrow))
        //    {
        //        transform.Rotate(0, Time.deltaTime * clockwise, 0);
        //    }
        //    else if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        //    }
        //}
    }

    public void PickUp()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            playerAnimations.SetTrigger("PickingUp");
            canMove = false;
            pickupTime = pickupTimer;
        }
    }

    public void PickUpTimer()
    {
        if (pickupTime > 0)
        {
            pickupTime -= Time.deltaTime;
        }
        else if (pickupTime <= 0)
        {
            canMove = true;
        }
    }

    public void ShrinkPlayer()
    {
        gameObject.transform.localScale += scaleDecreaser;

        if (gameObject.transform.localScale.x <= 0.7f)
        {
            GameOver();
        }

        sizeLerp = Mathf.InverseLerp(endSize, startSize, gameObject.transform.localScale.x);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Lose");
    }

    public void MapCheck()
    {
        if(atGopherEntrance == true && Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.transform.localScale.x <= 2.5)
            {
                gameObject.transform.position = gopherSpawnPoint;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if(atGopherExit == true && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = gopherExitPoint;
        }
    }

    public void Sound()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            playerAudioSource.PlayOneShot(walkSound);
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.name == "GopherEntrance")
        {
            atGopherEntrance = true;
            if(transform.localScale.x > 2.5)
            {
                cannotEnter.SetActive(true);
            } else if(transform.localScale.x <= 2.5)
            {
                canEnter.SetActive(true);
                cannotEnter.SetActive(false);
            }
        }

        if (trigger.gameObject.name == "GopherExit")
        {
            atGopherExit = true;
            canExit.SetActive(true);
        }

        if (trigger.gameObject.tag == "Pool")
        {
            poolCamera.enabled = true;
            thirdPerson.enabled = false;
        }

        if (trigger.gameObject.tag == "PowerUp")
        {
            powerUpTime = powerUpTimer;
            playerAudioSource.PlayOneShot(powerUpSound);
            Destroy(trigger.gameObject);
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.name == "GopherEntrance")
        {
            atGopherEntrance = false;
            if (transform.localScale.x > 2.5)
            {
                cannotEnter.SetActive(false);
            }
            else if (transform.localScale.x <= 2.5)
            {
                canEnter.SetActive(false);
                cannotEnter.SetActive(false);
            }
        }

        if (trigger.gameObject.name == "GopherExit")
        {
            atGopherExit = false;
            canExit.SetActive(false);
        }

        if (trigger.gameObject.tag == "Pool")
        {
            poolCamera.enabled = false;
            thirdPerson.enabled = true;
        }
    }
}
