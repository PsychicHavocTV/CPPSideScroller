using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarnacleRock : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.gameOver = true;
        }
        else if (other.tag == "Despawn")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("PlayerPlaceholder");
        }
    }
}
