using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed = 2.0f;
    public float max;
    public float min;
    public bool moveX = true;
    public bool openLeft = true;
    public bool isClosing = true;
    public AudioClip[] clips;
    private GameObject player;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        if (moveX)
        {
            max += transform.position.x;
            min += transform.position.x;
        }
        else
        {
            max += transform.position.z;
            min += transform.position.z;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float Offest = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isClosing)
                {
                    isClosing = true;
                }
                else
                {
                    isClosing = false;
                }
            }
        }

        if (moveX)
        {
            if (openLeft)
            {
                if (isClosing)
                {
                    if (max > transform.position.x)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x + Offest, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    if (min < transform.position.x)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x - Offest, transform.position.y, transform.position.z);
                    }
                }
            }
            else
            {
                if (isClosing)
                {
                    if (min < transform.position.x)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x - Offest, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    if (max > transform.position.x)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x + Offest, transform.position.y, transform.position.z);
                    }
                } 
            }
        }
        else
        {
            if (openLeft)
            {
                if (isClosing)
                {
                    if (max > transform.position.z)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Offest);
                    }
                }
                else
                {
                    if (min < transform.position.z)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Offest);
                    }
                }
            }
            else
            {
                if (isClosing)
                {

                    if (min < transform.position.z)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Offest);
                    }
                }

                else
                {
                    if (max > transform.position.z)
                    {
                        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Offest);
                    }
                }
            }
        }
    }
}
