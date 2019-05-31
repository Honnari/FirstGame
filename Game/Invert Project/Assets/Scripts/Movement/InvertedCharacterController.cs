using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedCharacterController : MonoBehaviour
{
    [SerializeField]
    private float walkingspeed, jumpspeed, haltspeed; // allows us to still edit these variables outside the editer but ensures we cant call upon them from other scripts. 

    public bool grounded; // true or false statements.
    public bool ismoving;

    public Transform GroundTraceStart; // start point for our raycast line.
    public Transform GroundTraceEnd; // end point for our raycast line.

    public LayerMask ceilinglayer; // creates a variable to store a layer.

    public GameObject Player, otherplayer, normalplayercam, invertedplayercam; // creates a empty slot within the hierarchy we can use to target a gameobject.
    
    private Rigidbody2D rb2d; // creates a variable to our rigidbody.

    void Start()
    {
        Player.GetComponent<InvertedCharacterController>().enabled = false; // calls upon the script we want that is attached to what gameobject we want.
        otherplayer.GetComponent<NormalCharacterController>();
        rb2d = GetComponent<Rigidbody2D>(); // calls upon our rigidbody from the editor.
    }

    void Update()
    {
        Movement();
        Raycasting();
    }

    void Movement()
    {
        if (Input.GetKey("a") || Input.GetKey("d")) // if the player is pressing a or d is moving becomes true else false.
        {
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

        if (Input.GetKeyDown("space") && grounded == true) // only allows us to jump if we are grounded and we press space.
        {
            rb2d.velocity = Vector2.down * jumpspeed;
        }

        if (Input.GetKeyDown("e") && grounded == true) // only allows us to switch characters if we are grounded and press E whilst not moving. 
        {
            if (ismoving == false)
            {
                rb2d.velocity = new Vector2(haltspeed, rb2d.velocity.y); // halts our character. 
                Player.GetComponent<InvertedCharacterController>().enabled = false;
                otherplayer.GetComponent<NormalCharacterController>().enabled = true;
                invertedplayercam.SetActive(false);
                normalplayercam.SetActive(true);
            }
        }
    }

    void Raycasting()
    {
        Debug.DrawLine(GroundTraceStart.transform.position, GroundTraceEnd.position, Color.green);
        grounded = Physics2D.Linecast(GroundTraceStart.transform.position, GroundTraceEnd.position, 1 << LayerMask.NameToLayer("Ceiling")); // draws a line from the start and end point in our game world. 
    }

    void FixedUpdate()
    {
        float Groundedmovement = Input.GetAxis("Horizontal"); // creates a variable for the horizontal movement.
        rb2d.velocity = new Vector2(Groundedmovement * walkingspeed, rb2d.velocity.y); //speed in which we walk.
    }
}
