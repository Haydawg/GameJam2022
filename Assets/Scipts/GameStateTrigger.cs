using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTrigger : MonoBehaviour
{
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameState.boomBoxOn = true;
        }
    }
}
