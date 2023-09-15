using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject player;
    PlayerController pc;
    public GameObject seal;
    public MeshRenderer mr;

    public bool canspawn;
    public bool attemptSpawn = false;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerBodyPH");
        pc = player.GetComponentInChildren<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if(timer <= 0)
        {
            canspawn = true;
            if(canspawn == true)
            {
                Instantiate(seal, this.gameObject.transform.position, seal.transform.rotation);
                canspawn = false;
            }
            timer = 3;
        }
        else
        {
            timer -= 1 * Time.deltaTime;
            if(timer <= 3 && timer >= 0.5f)
            {
                this.gameObject.transform.position = new Vector3(-4.29f, player.transform.position.y, 0);
                canspawn = false;
            }
        }

=======
        if (GameManager.Instance.gameOver == false)
        {
            if (pc.runDistanceTravelled >= 700)
            {
                if(chanceTimer <= 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        chance = (int)Random.Range(0, 10);
                        if (chance <= 3)
                        {
                            canspawn = true;
                        }
                        if (i >= 2)
                        {
                            attemptSpawn = false;
                        }
                    }
                    chanceTimer = 5;
                }
                else
                {
                    chanceTimer -= 1 * Time.deltaTime;
                }
                
                if(chance > 3 )
                {
                    this.gameObject.transform.position = new Vector3(-5.79f, player.transform.position.y + 0.34f, player.transform.position.z);
                    if(chance < 0)
                    {
                        chance = 0; //(int)Random.Range(0, 5);
                    }
                }
                else if(chance <= 3 && canspawn == true)
                {
                    if (timer <= 0)
                    {
                        if (mr.enabled == true)
                        {
                            mr.enabled = false;
                        }
                        Instantiate(seal, this.gameObject.transform.position, seal.transform.rotation);
                        timer = 3;
                        canspawn = false;
                        attemptSpawn = false;
                    }
                    else
                    {
                        if (mr.enabled == false)
                        {
                            mr.enabled = true;
                        }
                        timer -= 1 * Time.deltaTime;
                        if (timer <= 3 && timer >= 0.5f)
                        {
                            this.gameObject.transform.position = new Vector3(-5.79f, player.transform.position.y + 0.34f, player.transform.position.z);
                        }
                    }
                    if(chanceTimer <= 0)
                    {
                        chance = (int)Random.Range(0, 5);
                    }
                }
            }
        }
>>>>>>> Stashed changes
    }
}
