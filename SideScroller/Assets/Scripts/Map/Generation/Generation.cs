using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Generation : MonoBehaviour
{
    // Initialization
    private GameObject[] obstaclePrefabs;
    private GameObject[] coinStacks;
    //private float InitialScrollSpeed = x;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        while (true) //replace "true" with a player alive check
        {
            yield return new WaitForSeconds(1f);

            //spawn coin

            Time.timeScale *= 0.995f;

            //Time.timeScale = 1;
        }
    }
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