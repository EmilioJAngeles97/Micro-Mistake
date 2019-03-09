using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // player movement
    private Rigidbody rb;
    public float speed;
    public float clockwise;
    public float counterClockwise;

    public bool canMove;
    public float pickupTime;
    public float pickupTimer;

    private Vector3 scaleDecreaser;
    public float scaleAmount;

    private Animator playerAnimations;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
        clockwise = 100f;
        counterClockwise = -100f;

        playerAnimations = GetComponent<Animator>();
        pickupTime = 0;
        pickupTimer = 3;

        scaleAmount = -0.002f;
        scaleDecreaser = new Vector3(scaleAmount, scaleAmount, scaleAmount);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.position += transform.forward * Time.deltaTime * speed;
                playerAnimations.SetBool("WalkingForward", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.position -= transform.forward * Time.deltaTime * speed;
                playerAnimations.SetBool("WalkingBackward", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.position -= transform.right * Time.deltaTime * speed;
                playerAnimations.SetBool("WalkingLeft", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.position += transform.right * Time.deltaTime * speed;
                playerAnimations.SetBool("WalkingRight", true);
            }
            else
            {
                playerAnimations.SetBool("WalkingForward", false);
                playerAnimations.SetBool("WalkingBackward", false);
                playerAnimations.SetBool("WalkingRight", false);
                playerAnimations.SetBool("WalkingLeft", false);
            }

            // Rotation
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, Time.deltaTime * clockwise, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimations.SetTrigger("PickingUp");
                canMove = false;
                pickupTime = pickupTimer;
            }
        }

        if(pickupTime > 0)
        {
            pickupTime -= Time.deltaTime;
        } else if (pickupTime <= 0)
        {
            canMove = true;
        }

        gameObject.transform.localScale += scaleDecreaser;
    }
}
