using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
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
    public Vector3 moveTo;
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
                agent.SetDestination(moveTo);
            }
            else
            {
                agent.SetDestination(transform.position);
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
            agent.speed = 2;
            // chase after player
            if (canMove)
            {
                moveTo = (player.transform.position);
                agent.SetDestination(moveTo);
            }
            else
            {
                Debug.Log(canMove);
                agent.SetDestination(transform.position);
            }
        }
        else
        {
            agent.speed = 1;
        }
        agent.SetDestination(moveTo);
        moveTo.y = transform.position.y;
        //direction = agent.velocity.normalized;
        direction = transform.InverseTransformDirection(agent.velocity.normalized);
        Debug.Log(direction);
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
            if (Vector3.Distance(transform.position, player.transform.position) < 1)
            {
                gameState.boomBoxOn = true;
            }
        }
        else if (alert)
        {
            if((Vector3.Distance(transform.position, player.transform.position) < 0.2f))
            {
                player.GetComponent<PlayerController>().playerCaught = true;
            }
        }

    }
}
