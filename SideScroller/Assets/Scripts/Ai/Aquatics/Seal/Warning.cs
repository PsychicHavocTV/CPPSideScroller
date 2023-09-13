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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
