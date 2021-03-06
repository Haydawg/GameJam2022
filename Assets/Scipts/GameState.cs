using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    public bool boomBoxOn;

    public GameObject alertSlide;

    private float cameraMoveSpeed = 2;
    private bool firstAlerted;
    private bool unAlerted;
    private NpcController[] enemies;
    private PlayerController player;
    private GameObject cameraPivot;
    private CameraController cameraController;
    private GameObject closestEnemy = null;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        boomBoxOn = false;
        unAlerted = true;
        firstAlerted = false;
        enemies = FindObjectsOfType<NpcController>();
        cameraPivot = GameObject.Find("CameraPivot");
        cameraController = FindObjectOfType<CameraController>();

    }

        // Update is called once per frame
    void Update()
    {
        switch (boomBoxOn)
        {
            case true:
                player.boomBoxOn = true;
                if (unAlerted)
                {
                    StartCoroutine(EnemyAlerted(7));
                }
                break;
            case false:
                player.boomBoxOn = false;
                break;
        }
        if (boomBoxOn)
        {

        }
        if (firstAlerted)
        {
            cameraPivot.transform.position = Vector3.MoveTowards(cameraPivot.transform.position, closestEnemy.transform.position, cameraMoveSpeed * Time.deltaTime);
        }
    }
    GameObject GetClosestEnemy()
    {
        float minDistance = Mathf.Infinity;
        foreach (NpcController enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.gameObject.transform.position, player.transform.position);
            if (distance < minDistance)
            {
                closestEnemy = enemy.gameObject;
                minDistance = distance;
            }
        }
        return closestEnemy;
    }
    IEnumerator EnemyAlerted(int time)
    {
        unAlerted = false;
        player.canMove = false;
        cameraController.firstAlerted = true;
        closestEnemy = GetClosestEnemy();
        closestEnemy.GetComponent<NpcController>().alert = true;
        closestEnemy.GetComponent<NpcController>().canMove = false;
        firstAlerted = true;
        yield return new WaitForSeconds(time / 2);
        alertSlide.SetActive(true);
        yield return new WaitForSeconds(time / 2);
        cameraController.firstAlerted = false;
        firstAlerted = false;
        player.canMove = true;
        closestEnemy.GetComponent<NpcController>().canMove = true;
        foreach (NpcController enemy in enemies)
        {
            enemy.alert = true;
        }
    }
    public void PauseTime()
    {
        Time.timeScale = 0;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
   
}
