using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite[] sprites;
    public float playerSpeed = 1;
    public bool boomBoxOn = false;
    public float boomBoxVolume = 50;
    private Vector3 moveTo;
    private SpriteRenderer spriteRenderer;
    private CharacterController controller;
    private AudioSource boomBoxAudio;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boomBoxAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (boomBoxOn)
        {
            case true:
                playerSpeed = 2;
                boomBoxAudio.volume = boomBoxVolume;
                if (!boomBoxAudio.isPlaying)
                {
                    boomBoxAudio.Play();
                }
                break;

             case false:
                playerSpeed = 1;
                if (boomBoxAudio.isPlaying)
                {
                    boomBoxAudio.Stop();
                }
                break;
        }


        // Player Movement
        moveTo = Vector3.zero;
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        moveTo += (transform.forward * y * playerSpeed * Time.deltaTime);
        moveTo += (transform.right * x * playerSpeed * Time.deltaTime);

        controller.Move(moveTo);
        if (moveTo.y > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveTo.y < 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, 45, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, -45, 0);
        }

    }
}
