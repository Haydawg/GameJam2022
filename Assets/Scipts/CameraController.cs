using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool firstAlerted = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!firstAlerted)
        {
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
    }
}
