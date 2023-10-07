using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public GameObject ground;
    public GameObject objectsHolder;    
    public float floorSpeed;
    public PlayerController pc;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
            ground.transform.position += Vector3.left * pc.speed * Time.deltaTime;
            objectsHolder.transform.position += Vector3.left * pc.speed * Time.deltaTime;
        }
    }
}
