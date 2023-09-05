using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public Transform floorPosition;
    public Transform maxPosition;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y < maxPosition.transform.position.y && Input.GetMouseButton(0))
        {
            player.transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (player.transform.position.y > (floorPosition.position.y + 0.37f) && !Input.GetMouseButton(0))
        {
            //rb.useGravity = true;
            player.transform.position += Vector3.down * (speed / 1.8f) * Time.deltaTime;
        }
    }
}
