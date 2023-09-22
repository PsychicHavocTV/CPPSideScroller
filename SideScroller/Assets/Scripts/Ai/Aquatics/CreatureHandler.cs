using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureHandler : MonoBehaviour
{

    public CreatureObjects cO;
    public Creature creatureType;
    public GameObject creatureBody;
    public GameObject testCreature;
    //public GameObject minimumSpawnHeight;
    private SpawnHandler sH;
    private CreatureHandler cH;
    float maxHeight = 0;
    [SerializeField]
    float ypos = 0;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    iTween.EaseType easeType;
    bool moveComplete = true;
    bool posGenerated = false;

    // Spawn the creature.
    /// <summary>
    /// <c>SpawnCreature</c> Gets all the information needed, then spawns a new creature into the game.
    /// </summary>
    public void SpawnCreature()
    {

        GameObject oldCreature = creatureBody;

        Vector3 tempPos = new Vector3(24.35f, 1.23f, 1.89f);
        creatureBody = Instantiate(testCreature, tempPos, testCreature.transform.rotation); // Spawn the creature at the temporary position.
        creatureBody.name = cO.name; // Rename the object accordingly.
        creatureType = creatureBody.GetComponent<Creature>();
        creatureType.enabled = true;
        cO = creatureType.creatureType;
        cO.cH = cH;


        creatureBody.transform.parent = GameObject.Find("Creatures").transform;
        cH = creatureBody.GetComponent<CreatureHandler>();
        cH.enabled = true;

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
            timer = 5;
        }
        Destroy(oldCreature);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Despawn")
        {
            if (cO.shark == true)
            {
                SpawnCreature();
            }
            else if (cO.seal == true)
            {
                Destroy(creatureBody);
            }
        }

        if (other.tag == "Player")
        {
            GameManager.Instance.gameOver = true;
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



    /// <summary>
    /// <c>SharkBehaviour</c> handles shark mechanics.
    /// <para><description>Move the shark to the left using its Vector3, multiplied by its speed and deltaTime.</description></para>
    /// <para><description>If the timer has reached zero (0), generate a position to move to on the Y axis between the range of 0.8 and 7.4, otherwise keep counting the timer down every second.</description></para>
    /// <para><description>Move the shark up or down (using its Y axis) to the generated position.</description></para>
    /// </summary>
    public void SharkBehaviour()
    {
        creatureBody.transform.position += Vector3.left * cO.creatureSpeed * Time.deltaTime; // Move the shark to the left.

        if(timer <= 0) // If the timer has reached ZERO (0)
        {
            // Generate a random number between 0 and 3, and create a new Y position for the shark to move to later, and reset the timer.
            ypos = (float)Random.Range(0.8f, 7.4f);
            timer = 1.51f;
        }
        else if (timer > 0)
        {
            timer -= 1 * Time.deltaTime; // Count the timer down by 1 every second.
        }

        // If the sharks Y position doesnt already equal the newly generated Y position, and the new Y position is higher than the sharks current Y Position
        if (creatureBody.transform.position.y != ypos && ypos > creatureBody.transform.position.y)
        {
            creatureBody.transform.position += Vector3.up * 5 * Time.deltaTime; // Move the shark up multiplied by its speed.
        }

        // If the sharks Y position doesnt already equal the newly generated Y position, and the new Y position is lower than the sharks current Y Position
        if (creatureBody.transform.position.y != ypos && ypos < creatureBody.transform.position.y)
        {
            creatureBody.transform.position += Vector3.down * 5 * Time.deltaTime; // Move the shark down multiplied by its speed.
        }
    }

    /// <summary>
    /// <c>SealBehaviour</c> only moves the seal to the left using its Vector3, multiplied by its speed and deltaTime.
    /// <para><description>FOR THE FULL SEAL BEHAVIOUR, SEE THE "WARNING" SCRIPT.</description></para>
    /// </summary>
    public void SealBehaviour()
    {
        creatureBody.transform.position += Vector3.left * cO.creatureSpeed * Time.deltaTime;
    }
}