using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public GameObject ground;
    public GameObject objectsHolder;
    public float floorSpeed;

    // Update is called once per frame
    void Update()
    {
            ground.transform.position += Vector3.left * floorSpeed * Time.deltaTime;
            objectsHolder.transform.position += Vector3.left * floorSpeed * Time.deltaTime;
    }
}
