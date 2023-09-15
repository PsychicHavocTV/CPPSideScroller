using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Warning : MonoBehaviour
{
    GameObject player;
    public GameObject seal;
    public bool canspawn;
    public float timer;
    public float chanceTimer;
    public int chance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(chanceTimer < 0)
        {
            chance = (int)Random.Range(0, 5);
            chanceTimer = 5;
        }
        else
        {
            chanceTimer -= 1 * Time.deltaTime;
        }
        

        if(chance < 3 )
        {
            this.gameObject.transform.position = new Vector3(0, player.transform.position.y, 0);
            if(chance < 0)
            {
                chance = (int)Random.Range(0, 5);
            }
            
        }
        else if(chance > 3)
        {
            if (timer <= 0)
            {
                Instantiate(seal, this.gameObject.transform.position, seal.transform.rotation);
                timer = 3;
            }
            else
            {
                timer -= 1 * Time.deltaTime;
                if (timer <= 3 && timer >= 0.5f)
                {
                    this.gameObject.transform.position = new Vector3(-4.29f, player.transform.position.y, 0);
                }
            }
            if(chanceTimer <= 0)
            {
                chance = (int)Random.Range(0, 5);
            }
            
        }




    }
}
