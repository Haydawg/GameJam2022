using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool boomBoxOn;

    private bool firstAlerted = false;
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
                StartCoroutine(EnemyAlerted(5));
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
            cameraPivot.transform.position = closestEnemy.transform.position;
        }
    }
    GameObject GetClosestEnemy()
    {
        float minDistance = Mathf.Infinity;
        foreach (NpcController enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.gameObject.transform.position, transform.position);
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
        cameraController.firstAlerted = true;
        closestEnemy = GetClosestEnemy();
        firstAlerted = true;
        yield return new WaitForSeconds(time);
        cameraController.firstAlerted = false;
        firstAlerted = false;
        foreach (NpcController enemy in enemies)
        {
            enemy.alert = true;
        }
    }
}
