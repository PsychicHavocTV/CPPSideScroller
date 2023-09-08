using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatureHandler : MonoBehaviour
{
    public CreatureObjects cO;
    public Creature creatureType;
    public GameObject creatureBody;
    public GameObject testCreature;
    private SpawnHandler sH;
    private CreatureHandler cH;
    float maxHeight = 0;
    [SerializeField]
    private GameObject warningSpot;
    [SerializeField]
    int ypos = 0;
    [SerializeField]
    float timer2 = 0;
    Warning canSpawn;
    public bool canMove = true;

    // Spawn the creature.
    public void SpawnCreature()
    {
        if(cO.shark == true)
        {
            Debug.Log("spawned shark");
            Vector3 tempPos = new Vector3(24.35f, 1.23f, 1.89f); // Set a temporary position for the creature to spawn at.
            creatureBody = Instantiate(testCreature, tempPos, testCreature.transform.rotation); // Spawn the creature at the temporary position.

            if (sH == null)
            {
                sH = GetComponent<SpawnHandler>(); // If not found, set a new Spawn Handler.
            }
            maxHeight = sH.maxHeightPos.y;
            Vector3 pos = sH.position; // create a new position to move the new creature to.
            pos.y = (int)Random.Range(sH.minHeightPos.y, sH.maxHeightPos.y); // Change the Y position to a random position within the minimum and maximum heights.
            creatureBody.transform.position = pos; // Move the creature to the updated position.
            if (cO.seal == true)
            {
                timer2 = 5;
            }
        }
        //else if(cO.seal == true)
        //{
        //    Debug.Log("spawned seal");
        //    warningSpot = GameObject.FindWithTag("SealSpawn");
        //    creatureBody = Instantiate(testCreature, warningSpot.transform.position, testCreature.transform.rotation);
        //}
        
        creatureBody.name = cO.name; // Rename the object accordingly.
        creatureType = creatureBody.GetComponent<Creature>();
        creatureType.enabled = true;
        cO = creatureType.creatureType;


        creatureBody.transform.parent = GameObject.Find("Creatures").transform;
        cH = creatureBody.GetComponent<CreatureHandler>();
        cH.enabled = true;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Despawn")
        {
            Destroy(creatureBody);
            canMove = false;
            SpawnCreature();
        }

        if (other.tag == "Player")
        {
<<<<<<< HEAD
            SceneManager.LoadScene(1);
            //Debug.Log("Kill Player");
=======
            GameManager.Instance.gameOver = true;
>>>>>>> origin/emmanuelupdate
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
            // Check the creature type.
            if (cO.shark == true)
            {
                SharkBehaviour();
            }
            else if (cO.seal == true)
            {
                SealBehaviour();
            }
        }
    }

    public void SharkBehaviour()
    {
        creatureBody.transform.position += Vector3.left * cO.creatureSpeed * Time.deltaTime; // Move the shark to the left.

        if(timer2 <= 0) // If the timer has reached ZERO (0)
        {
            // Generate a random number between 0 and 3, and create a new Y position for the shark to move to later, and reset the timer.
            ypos = (int)Random.Range(0, 3);
            timer2 = 2;
        }
        else
        {
            timer2 -= 1 * Time.deltaTime; // Count the timer down by 1 every second.
        }

        // If the sharks Y position doesnt already equal the newly generated Y position, and the new Y position is higher than the sharks current Y Position
        if (creatureBody.transform.position.y != ypos && ypos > creatureBody.transform.position.y)
        {
            creatureBody.transform.position += Vector3.up * cO.creatureSpeed * Time.deltaTime; // Move the shark up multiplied by its speed.
        }
        // If the sharks Y position doesnt already equal the newly generated Y position, and the new Y position is lower than the sharks current Y Position
        else if (creatureBody.transform.position.y != ypos && ypos < creatureBody.transform.position.y)
        {
            creatureBody.transform.position += Vector3.down * cO.creatureSpeed * Time.deltaTime; // Move the shark down multiplied by its speed.
        }
        else
        {
            creatureBody.transform.position += Vector3.left * cO.creatureSpeed * Time.deltaTime; // Move the shark to the left.
        }
    }

    public void SealBehaviour()
    {
        //Debug.Log("I am a seal.");
        creatureBody.transform.position += Vector3.left * (cO.creatureSpeed * 3) * Time.deltaTime; // Move the shark to the left.
    }
}