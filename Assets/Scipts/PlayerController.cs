using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1;
    public bool boomBoxOn = false;
    public float boomBoxVolume = 50;
    public GameObject losePanel;
    public AudioSource boomBoxAudio;
    public AudioSource feet;
    public AudioClip[] quietFootStepClips;
    public AudioClip[] loudFootStepClips;
    public bool canMove = true;
    public bool playerCaught = false;
    public GameObject music;
    public ParticleSystem notes;
    private Vector3 moveTo;
    private SpriteRenderer spriteRenderer;
    private CharacterController controller;
    private Animator anim;
    Vector3 rotationVector = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        losePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (boomBoxOn)
        {
            case true:
                anim.SetBool("isRunning", true);
                controller.height = 0.8f;
                playerSpeed = 2;
                //feet.clip = loudFootStepClips[Random.Range(0, loudFootStepClips.Length)];
                boomBoxAudio.volume = boomBoxVolume;
                if (!boomBoxAudio.isPlaying)
                {
                    boomBoxAudio.Play();
                    notes.Play();
                }
                break;

             case false:
                anim.SetBool("isRunning", false);
                controller.height = 0.60f;
                playerSpeed = 1;
                //feet.clip = quietFootStepClips[Random.Range(0, quietFootStepClips.Length)];
                if (boomBoxAudio.isPlaying)
                {
                    boomBoxAudio.Stop();
                    music.SetActive(false);
                    notes.Pause();
                }
                break;
        }
        
        // Player Movement
        moveTo = Vector3.zero;
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        moveTo += (transform.forward * z * playerSpeed * Time.deltaTime);
        moveTo += (transform.right * x * playerSpeed * Time.deltaTime);
        
        if (canMove)
        {
            controller.Move(moveTo);
        }

        anim.SetFloat("MoveX", x);
        anim.SetFloat("MoveZ", z);
 
        if (x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


        
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotationVector.y += 45;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotationVector.y -= 45;
        }

        Quaternion rotation = Quaternion.Euler(rotationVector);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * 0.01f);
        if(playerCaught)
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
        }
        Debug.Log(Time.timeScale);
    }
    
    public void FootSounds()
    {
        if (!boomBoxOn)
        {
            feet.PlayOneShot(quietFootStepClips[Random.Range(0, quietFootStepClips.Length)]);
        }
        else if (boomBoxOn)
        {
            feet.PlayOneShot(quietFootStepClips[Random.Range(0, loudFootStepClips.Length)]);
        }
    }
}
