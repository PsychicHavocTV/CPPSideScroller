using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Generation : MonoBehaviour
{
    // Initialization
    private PlayerController playerController;
    private GameObject[] obstaclePrefabs;
    private GameObject[] coinPrefab;

    // Obstacle Initialization
    private int lastObstacleIndex = -1;
    private int sameObstacleCount = 0;

    // Coin Initilization


    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //StartCoroutine(SpawnCoin());
    }

    void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
            // Move the game world to the left at current speed
            transform.position -= new Vector3(playerController.runspeed * Time.deltaTime, 0, 0);
            playerController.runDistanceTravelled += playerController.runspeed * Time.deltaTime;

            // Check if it's time to generate a new obstacle or coin
            GenerateObstacle();

            GenerateCoin();

            // Increase speed gradually to make game harder
            playerController.runspeed += 0.01f * Time.deltaTime;
        }
    }
      
    void GenerateObstacle()
    {
        if ((int)playerController.runDistanceTravelled % 100 == 0)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

            // If the same obstacle has been used 3 times in a row or no obstacle more than once, change the obstacle
            if ((obstacleIndex == lastObstacleIndex && sameObstacleCount >= 2) || (obstaclePrefabs[obstacleIndex] == null && sameObstacleCount >= 1))
            {
                do
                {
                    obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
                }
                while (obstacleIndex == lastObstacleIndex);
            }

            lastObstacleIndex = obstacleIndex;
            sameObstacleCount = (obstacleIndex == lastObstacleIndex) ? sameObstacleCount + 1 : 0;

            if (obstaclePrefabs[obstacleIndex] != null)
            {
                Instantiate(obstaclePrefabs[obstacleIndex]);
            }
        }
    }

    bool GenerateCoin()
    {
        // Implement this function based on your game's logic
        return false;
    }

    /*void GenerateCoin()
    {
        // Randomly select a coin pattern prefab from the list
        GameObject coinPatternPrefab = coinPrefab[Random.Range(0, coinPrefab.Length)];

        // Determine the position (you might want to adjust this based on your game's logic)
        Vector3 position = new Vector3(transform.position.x + 10, 0, 0);

        // Instantiate the coin pattern at the determined position
        Instantiate(coinPatternPrefab, position, Quaternion.identity);
    }*/

    /*IEnumerator SpawnCoin()
    {
        while (GameManager.Instance.gameOver == false) // While Gameover == false
        {
            yield return new WaitForSeconds(1f);

            //spawn coin

            Time.timeScale *= 0.995f;

            //Time.timeScale = 1;
        }
    }*/

    /*

    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;
    public float speed = 1.0f;
    private float distanceTraveled = 0.0f;

    void Start()
    {
        // Load obstacle prefabs and coin prefab
        // This is usually done in the Unity editor
    }

    void Update()
    {
        if (!PlayerIsDead())
        {
            // Move the game world to the left at current speed
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            distanceTraveled += speed * Time.deltaTime;

            // Check if it's time to generate a new obstacle or coin
            if (ShouldGenerateObstacle())
            {
                GenerateObstacle();
            }

            if (ShouldGenerateCoin())
            {
                GenerateCoin();
            }

            // Increase speed gradually to make game harder
            speed += 0.01f * Time.deltaTime;
        }
    }

    bool PlayerIsDead()
    {
        // Implement this function based on your game's logic
        return false;
    }

    bool ShouldGenerateObstacle()
    {
        // Implement this function based on your game's logic
        return false;
    }

    bool ShouldGenerateCoin()
    {
        // Implement this function based on your game's logic
        return false;
    }

    void GenerateObstacle()
    {
        // Randomly select an obstacle prefab from the list
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Randomly determine the position (within game boundaries)
        Vector3 position = new Vector3(transform.position.x + 10, Random.Range(-5, 5), 0);

        // Instantiate the obstacle at the determined position
        Instantiate(obstaclePrefab, position, Quaternion.identity);
    }

    void GenerateCoin()
    {
        // Randomly determine the position (within game boundaries)
        Vector3 position = new Vector3(transform.position.x + 10, Random.Range(-5, 5), 0);

        // Instantiate the coin at the determined position
        Instantiate(coinPrefab, position, Quaternion.identity);
    }
}


    */
}


/*

Initialize game:
    Set initial speed for scrolling
    Load obstacle prefabs (icebergs, sharks, seals, big fish, mines)
    Load coin prefab

Start game loop:
    While player is not dead:
        Move the game world to the left at current speed
        Generate floor and sky boundary

        For each frame:
            Check if it's time to generate a new obstacle or coin based on distance traveled

            If it's time to generate a new obstacle:
                Randomly select an obstacle prefab from the list
                Randomly determine the position (within game boundaries)
                Instantiate the obstacle at the determined position

            If it's time to generate a new coin:
                Randomly determine the position (within game boundaries)
                Instantiate the coin at the determined position

        Increase speed gradually to make game harder

*/