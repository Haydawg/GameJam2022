using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxX = 1;
    public float minX = 0;
    private bool isClosing;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        maxX += transform.position.x;
        minX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float Offest = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            if(Input.GetKeyDown(KeyCode.F))
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
        if (isClosing)
        {
            if (transform.position.x < maxX)
            {
                transform.position = new Vector3(transform.position.x + Offest, transform.position.y , transform.position.z);
            }
        }
        else
        {
            if (transform.position.x >= minX)
            {
                transform.position = new Vector3(transform.position.x - Offest, transform.position.y, transform.position.z);
            }
        }
    }
}
