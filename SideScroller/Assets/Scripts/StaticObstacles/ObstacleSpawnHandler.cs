using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class ObstacleSpawnHandler : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;

    public GameObject bSpawn;

    public GameObject BarnaclePrefab;

    [SerializeField]
    private int barnacleMinRun = 650;
    [SerializeField]
    private int icebergMinRun = 1500;
    [SerializeField]
    private int wreckageMinRun = 2000;

    [SerializeField]
    private int bSpawnChance = 5;

    [SerializeField]
    private float bChanceTimer = 5;

    [SerializeField]
    private bool barnacleCanSpawn = false;
    [SerializeField]
    private bool icebergCanSpawn = false;
    [SerializeField]
    private bool wreckageCanSpawn = false;

    [SerializeField]
    private bool bConditionMet = false;

    private void Start()
    {
        player = GameObject.Find("PlayerPlaceholder");
        pc = player.GetComponentInChildren<PlayerController>();
    }

    private void Update()
    {


        if (pc.runDistanceTravelled >= barnacleMinRun)
        {
            if (barnacleCanSpawn == false)
            {
                barnacleCanSpawn = true;
            }
        }

        if (barnacleCanSpawn == true)
        {
            if (bChanceTimer > 0)
            {
                bChanceTimer -= 1 * Time.deltaTime;
            }
            else if (bChanceTimer <= 0)
            {
                bSpawnChance = Random.Range(0, 7);

                if (bSpawnChance <= 2)
                {
                    bChanceTimer = Random.Range(3, 9);
                    StartCoroutine(SpawnBarnacle());
                }
            }
        }
    }

    private IEnumerator SpawnBarnacle()
    {
        GameObject bonusBarnacle1 = null;
        GameObject bonusBarnacle2 = null;
        GameObject bonusBarnacle3 = null;
        GameObject newObstacle = Instantiate(BarnaclePrefab, bSpawn.transform.position, BarnaclePrefab.transform.rotation);
        newObstacle.transform.parent = GameObject.Find("Obstacles").transform;
        for (int i = 0; i < 4; i++)
        {
            int a = Random.Range(1, 6);
            if (a <= 3)
            {
                yield return new WaitForSeconds(0.3f);
                if (bonusBarnacle1 == null)
                {
                    bonusBarnacle1 = Instantiate(BarnaclePrefab, bSpawn.transform.position, BarnaclePrefab.transform.rotation);
                    bonusBarnacle1.transform.parent = GameObject.Find("Obstacles").transform;
                }
                else if (bonusBarnacle1 == null && bonusBarnacle2 != null)
                {
                    bonusBarnacle2 = Instantiate(BarnaclePrefab, bSpawn.transform.position, BarnaclePrefab.transform.rotation);
                    bonusBarnacle2.transform.parent = GameObject.Find("Obstacles").transform;
                }
                else if (bonusBarnacle1 != null && bonusBarnacle2 != null && bonusBarnacle3 == null)
                {
                    bonusBarnacle3 = Instantiate(BarnaclePrefab, bSpawn.transform.position, BarnaclePrefab.transform.rotation);
                    bonusBarnacle3.transform.parent = GameObject.Find("Obstacles").transform;
                }
            }
        }
        StopCoroutine(SpawnBarnacle());
    }


}
