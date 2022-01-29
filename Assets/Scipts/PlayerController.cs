using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite[] sprites;
    public float playerSpeed = 1;
    public bool boomBoxOn = false;
    public float boomBoxVolume = 50;
    public AudioSource boomBoxAudio;
    public AudioSource feet;
    public AudioClip[] quietFootStepClips;
    public AudioClip[] loudFootStepClips;
    public bool canMove = true;
    public bool playerCaught = false;


    private Vector3 moveTo;
    private SpriteRenderer spriteRenderer;
    private CharacterController controller;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (boomBoxOn)
        {
            case true:
                playerSpeed = 2;
                //feet.clip = loudFootStepClips[Random.Range(0, loudFootStepClips.Length)];
                boomBoxAudio.volume = boomBoxVolume;
                if (!boomBoxAudio.isPlaying)
                {
                    boomBoxAudio.Play();
                }
                break;

             case false:
                playerSpeed = 1;
                //feet.clip = quietFootStepClips[Random.Range(0, quietFootStepClips.Length)];
                if (boomBoxAudio.isPlaying)
                {
                    boomBoxAudio.Stop();
                }
                break;
        }
        
        // Player Movement
        moveTo = Vector3.zero;
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        moveTo += (transform.forward * z * playerSpeed * Time.deltaTime);
        moveTo += (transform.right * x * playerSpeed * Time.deltaTime);
        
        if (moveTo == Vector3.zero)
        {
            anim.speed = 0;
            Debug.Log(anim.speed);
        }
        else
        {
            anim.speed = 1;
        }
        if (canMove)
        {
            controller.Move(moveTo);
            anim.speed = 1;
        }
        else
        {
            anim.speed = 0;
        }

        // flip sprite to match move direction
        if (moveTo.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveTo.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        //set animation parameters based of the move direction
        if (spriteRenderer.flipX == false)
        {
            anim.SetFloat("MoveX", x);
            anim.SetFloat("MoveZ", z);
        }
        else
        {
            anim.SetFloat("MoveX", -x);
            anim.SetFloat("MoveZ", z);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 45, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -45, 0);
        }

    }
}
