using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHandler : MonoBehaviour
{
    public CreatureObjects cO;
    public GameObject creatureBody;
    public GameObject testCreature;
    private SpawnHandler sH;
    private CreatureHandler cH;
    float timeHolder = 2;
    int moveTimer = 5;

    // Spawn the creature.
    public void SpawnCreature()
    {
        Vector3 tempPos = new Vector3(24.35f, 1.23f, 1.89f); // Set a temporary position for the creature to spawn at.
        creatureBody = Instantiate(testCreature, tempPos, testCreature.transform.rotation); // Spawn the creature at the temporary position.
        creatureBody.name = cO.name; // Rename the object accordingly.
        cH = creatureBody.GetComponent<CreatureHandler>();
        cH.enabled = true;

        if (sH == null)
        {
            sH = GetComponent<SpawnHandler>(); // If not found, set a new Spawn Handler.
        }
        Vector3 pos = sH.position; // create a new position to move the new creature to.
        pos.y = (int)Random.Range(sH.minHeightPos.y, sH.maxHeightPos.y); // Change the Y position to a random position within the minimum and maximum heights.
        creatureBody.transform.position = pos; // Move the creature to the updated position.
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Despawn")
        {
            Destroy(creatureBody);
            SpawnCreature();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void Update()
    {
        if (cO.shark == true)
        {
            SharkBehaviour();
        }
        else if (cO.seal == true)
        {
            SealBehaviour();
        }
    }

    public void SharkBehaviour()
    {
        Debug.Log(timeHolder);
        creatureBody.transform.position += Vector3.left * cO.creatureSpeed * Time.deltaTime;
        timeHolder -= 1 * Time.deltaTime;
        moveTimer = (int)timeHolder;

        if (moveTimer <= 0)
        {
            int moveChance = Random.Range(1, 10);
            if (moveChance <= 10)
            {
                // Move Up.
                if (creatureBody.transform.position.y < sH.maxHeightPos.y)
                {
                    creatureBody.transform.position += Vector3.up * 5 * cO.creatureSpeed * Time.deltaTime;
                    timeHolder = 2;
                }
                else
                {
                    moveChance = 11;
                }
            }
            if (moveChance > 10 && moveChance <= 20)
            {
                // Move Down.
                //creatureBody.transform.position += Vector3.down * 3 * cO.creatureSpeed * Time.deltaTime;
                timeHolder = 2;
            }
            if (moveChance > 20)
            {
                // Dont Move Up Or Down.
            }
        }
    }

    public void SealBehaviour()
    {
        Debug.Log("I am a seal.");
    }
}