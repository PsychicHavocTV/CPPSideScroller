using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHandler : MonoBehaviour
{
    public CreatureObjects cO;
    public Creature creatureType;
    public GameObject creatureBody;
    public GameObject testCreature;
    private SpawnHandler sH;
    private CreatureHandler cH;
    float timeHolder = 2;
    int moveChance = 0;
    float maxHeight = 0;
    [SerializeField]
    float ypos = 0;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    iTween.EaseType easeType;

    // Spawn the creature.
    public void SpawnCreature()
    {
        Vector3 tempPos = new Vector3(24.35f, 1.23f, 1.89f); // Set a temporary position for the creature to spawn at.
        creatureBody = Instantiate(testCreature, tempPos, testCreature.transform.rotation); // Spawn the creature at the temporary position.
        creatureBody.name = cO.name; // Rename the object accordingly.
        creatureType = creatureBody.GetComponent<Creature>();
        cO = creatureType.creatureType;

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

        if(timer <= 0)
        {
            ypos = (float)Random.Range(0f, 3f);
            timer = 2;
        }
        else
        {
            timer -= 1 * Time.deltaTime;
        }

        if(creatureBody.transform.position.y != ypos && ypos > creatureBody.transform.position.y)
        {
            creatureBody.transform.position += Vector3.up * cO.creatureSpeed * Time.deltaTime;
        }
        else if(creatureBody.transform.position.y != ypos && ypos < creatureBody.transform.position.y)
        {
            creatureBody.transform.position += Vector3.down * cO.creatureSpeed * Time.deltaTime;
        }
        
    }

    public void SealBehaviour()
    {
        Debug.Log("I am a seal.");
    }
}