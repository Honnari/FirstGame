using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCharacterController : MonoBehaviour
{
    [SerializeField]
    private float walkingspeed, jumpspeed, haltspeed, rotationspeed;


    public bool grounded;
    public bool ismoving;

    public Transform GroundTraceStart;
    public Transform GroundTraceEnd;

    public LayerMask groundlayer;

    public GameObject Player, otherplayer, invertedplayercam, normalplayercam;

    private Rigidbody2D rb2d;

    void Start()
    {
        otherplayer.GetComponent<InvertedCharacterController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Raycasting();
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb2d.velocity = Vector2.up * jumpspeed;
        }

        if (Input.GetKeyDown("e") && grounded == true)
        {
            if (ismoving == false)
            {
                rb2d.velocity = new Vector2(haltspeed, rb2d.velocity.y);
                Player.GetComponent<NormalCharacterController>().enabled = false;
                otherplayer.GetComponent<InvertedCharacterController>().enabled = true;
                invertedplayercam.SetActive(true);
                normalplayercam.SetActive(false);
            }
        }
    }

    void Raycasting()
    {
        Debug.DrawLine(GroundTraceStart.transform.position, GroundTraceEnd.position, Color.green);
        grounded = Physics2D.Linecast(GroundTraceStart.transform.position, GroundTraceEnd.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void FixedUpdate()
    {
        float Groundedmovement = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(Groundedmovement * walkingspeed, rb2d.velocity.y);
    }   
}
