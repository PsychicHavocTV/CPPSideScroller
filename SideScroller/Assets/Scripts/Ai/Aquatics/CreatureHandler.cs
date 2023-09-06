using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHandler : MonoBehaviour
{
    public CreatureObjects cO;
    public GameObject creatureBody;
    public GameObject despawnPos;

    

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
        if (creatureBody.transform.position.x <= despawnPos.transform.position.x)
        {
            Destroy(creatureBody);
        }
    }

    public void SharkBehaviour()
    {
        Debug.Log("I am a shark.");
        creatureBody.transform.position += Vector3.left * cO.creatureSpeed * Time.deltaTime;
    }

    public void SealBehaviour()
    {
        Debug.Log("I am a seal.");
    }
}