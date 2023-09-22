using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject player;
    PlayerController pc;
    public GameObject seal;
    public MeshRenderer mr;

    public bool canspawn;
    public bool attemptSpawn = false;
    public bool followPlayer = false;
    public bool countChance = true;

    public int chance = 0;
    public float timer = 2;
    public float chanceTimer = 5;
    public float followTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerBodyPH");
        pc = player.GetComponentInChildren<PlayerController>();
    }

    /// <summary>
    /// Here, <c>Update</c> handles all of the checking for the warning and for spawning seals.
    /// <para><description>If the gameOver BOOL in the GameManager is still false (meaning the player is currently doing a run and hasnt hit an obstacle),
    /// and the player has run AT LEAST 700 meters</description></para>
    /// <para><description>Set up a timer that counts down to give the seal a chance to spawn.</description></para>
    /// <para><description>Every time the chanceTimer has reached ZERO (0), generate a random number between zero (0) and ten (10), which will determine 
    /// what will happen.</description></para>
    /// <para><description>If the generated number (chance) is three (3) or less, set up a timer that, while counting, makes the WARNING object appear, 
    /// and follow the player along the Y axis.</description></para>
    /// <para><description>When the follow timer finished, make the WARNING object stay in one position for a short amount of time - one (1) to three (3) seconds - 
    /// before calling the <c>SpawnSeal</c> function.</description></para>
    /// </summary>
    void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
            // If the player has travelled AT LEAST 700 meters
            if (pc.runDistanceTravelled >= 700)
            {
                // Check if the game is ready to attempt spawning a seal.
                if (countChance == true)
                {
                    // If the chance countdown has reached zero (0)
                    if (chanceTimer <= 0)
                    {
                        // Randomly generate a number for the chance.
                        chance = Random.Range(0, 10);

                        // If the randomly generated number is three (3) or less, make the warning be able to follow the player.
                        if (chance <= 3)
                        {
                            followPlayer = true;
                            countChance = false;
                        }

                        // Randomly generate a random number for the chance counter.
                        chanceTimer = Random.Range(4, 8);
                    }
                    else
                    {
                        chanceTimer -= 1 * Time.deltaTime;
                    }
                }

                // If the warning is able to follow the player
                if (followPlayer == true)
                {
                    // If the amount of time the warning should follow the player still has time remaining
                    if (followTimer > 0)
                    {
                        // Show the sprite if it isn't already showing.
                        if (mr.enabled == false)
                        {
                            mr.enabled = true;
                        }

                        // Follow the player on their Y (Vertical) position.
                        this.gameObject.transform.position = new Vector3(-4.29f, player.transform.position.y, 0);

                        followTimer -= 1 * Time.deltaTime;
                    }

                    // Otherwise, if the follow timer is out of time
                    else if (followTimer <= 0)
                    {
                        // generate a random number between 1 and 3 for the amount of time the warning will wait before spawning a seal.
                        timer = Random.Range(1, 3);

                        // Reset the follow timer.
                        followTimer = 4;
                        followPlayer = false;

                        // Tell the game we are ready for it to spawn a seal.
                        canspawn = true;
                    }
                }

                // If the game is ready to spawn a seal
                if (canspawn == true)
                {

                    // If the warning has finished following the player, but the waiting timer has time left, dont move the warning and count down the timer.
                    if (timer > 0)
                    {
                        timer -= 1 * Time.deltaTime;
                    }

                    // Otherwise if the waiting timer is out of time
                    else if (timer <= 0)
                    {
                        canspawn = false;
                        countChance = true;

                        // Generate a random number between 1 and 3 for the next wait timer.
                        timer = Random.Range(1, 3);

                        // Spawn the seal.
                        SpawnSeal();
                    }
                }
            }
        }
    }

    /// <summary>
    /// <c>SpawnSeal</c> handles actually spawning a SEAL into the game.
    /// <para><description>If the WARNING object is showing, hide it, then spawn (INSTANTIATE) a new seal into the game at the position of the WARNING object.</description></para>
    /// </summary>
    public void SpawnSeal()
    {
        // Hide the warning sprite.
        mr.enabled = false;

        // Spawn the seal.
        Instantiate(seal, this.gameObject.transform.position, seal.transform.rotation);
        return;
    }
}
