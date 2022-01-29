using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed = 2.0f;
    public float max = 1;
    public float min = 0;
    public bool moveX = true;
    private bool isClosing;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        max += transform.position.x;
        min = transform.position.x;
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
            if (isClosing)
            {
                if (transform.position.x < max)
                {
                    transform.position = new Vector3(transform.position.x + Offest, transform.position.y, transform.position.z);
                }
            }
            else
            {
                if (transform.position.x >= min)
                {
                    transform.position = new Vector3(transform.position.x - Offest, transform.position.y, transform.position.z);
                }
            }
        }
        else
        {
            if (isClosing)
            {
                if (transform.position.z < max)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Offest);
                }
            }

            else
            {
                if (transform.position.z >= min)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Offest);
                }
            }
        }
        
    }
}
