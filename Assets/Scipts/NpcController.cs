using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public SphereCollider triggerCollider;
    public bool alert;
    public NavMeshAgent agent;
    public GameObject[] patrolLocations;
    public bool canMove = true;
 

    private GameObject player;
    private int currentPatrolLocation = 0;
    private SpriteRenderer spriteRenderer;
    private GameState gameState;
    private Vector3 currentPosition;
    private float moveSpeed;
    private Vector3 moveTo;
    private Vector3 direction;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        gameState = FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alert)
        {
            // patroll betweem Patrol location objects
            if (canMove)
            {
                agent.speed = 1;
            }
            else
            {
                agent.speed = 0;
            }
            
            if (transform.position == moveTo)
            {
                currentPatrolLocation++;
                if (currentPatrolLocation >= patrolLocations.Length)
                {
                    currentPatrolLocation = 0;
                }
            }
            moveTo = patrolLocations[currentPatrolLocation].transform.position;
        }
        else if (alert)
        {
            // chase after player
            moveTo = (player.transform.position);
            if (canMove)
            {
                agent.SetDestination(moveTo);
            }
            else
            {
                agent.SetDestination(transform.position);
            }
        }
        agent.SetDestination(moveTo);
        moveTo.y = transform.position.y;
        direction = agent.velocity.normalized;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveZ", direction.z);

        //rotate to face camera at the same time player does
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 45, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -45, 0);
        }
        ProximityCheck();
    }

    void ProximityCheck()
    {
        if (!alert)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 4)
            {
                gameState.boomBoxOn = true;
            }
        }
        else if (alert)
        {
            if((Vector3.Distance(transform.position, player.transform.position) < 1))
            {
                player.GetComponent<PlayerController>().playerCaught = true;
            }
        }

    }
}
