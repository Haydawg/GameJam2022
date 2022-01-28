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
   
    private int currentPatrolLocation = 0;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!alert)
        {
            // patroll betweem Patrol location objects
            agent.speed = 1;
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
            agent.speed = 2;
        }
        
        moveTo.y = transform.position.y;
        agent.destination = moveTo;
        direction =  transform.position - moveTo;
        // flip sprite to match move direction
        if (moveTo.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveTo.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        //set animation parameters based of the move direction
        if (spriteRenderer.flipX == false)
        {
            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveZ", direction.z);
        }
        else
        {
            anim.SetFloat("MoveX", -direction.x);
            anim.SetFloat("MoveZ", direction.z);
        }
        //rotate to face camera at the same time player does
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 45, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -45, 0);
        }
    }
}
