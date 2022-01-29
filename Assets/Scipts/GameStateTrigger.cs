using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTrigger : MonoBehaviour
{
    public GameObject[] triggerLocations;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        transform.position = triggerLocations[Random.Range(0, triggerLocations.Length)].transform.position;
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
