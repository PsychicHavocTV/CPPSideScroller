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
        if (Input.GetKey(KeyCode.A))
        {
            ground.transform.position += Vector3.left * floorSpeed * Time.deltaTime;
            objectsHolder.transform.position += Vector3.left * floorSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            ground.transform.position += Vector3.right * floorSpeed * Time.deltaTime;
            objectsHolder.transform.position += Vector3.right * floorSpeed * Time.deltaTime;
        }
    }
}
