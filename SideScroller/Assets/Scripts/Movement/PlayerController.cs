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
    private GameObject mapHolder;
    public CurrencyEarnt currency;
    public float speed;
    public float runDistanceTravelled = 0;
    private float runspeed = 5f;

    private Vector3 faceDirection;
    [SerializeField]
    private float rotateSpeed = 5;
    [SerializeField]
    private float rotateAngle = 0.5f;

    public float counter = 12;
    bool speedchanged = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Get the component information to collect coins during a run.
        mapHolder = GameObject.Find("MapPlaceholder");
        currency = mapHolder.GetComponentInChildren<CurrencyEarnt>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            currency.earntRunCurrency += 1;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
        }
    }

    /// <summary>
    /// <c>FixedUpdate</c> handles the distance calculation and player input.
    /// <para>runDistanceTravelled increases by 1.5 times the runspeed multiplied by deltaTime.</para>
    /// <para>runSpeed increases every second by ~0.75.</para>
    /// </summary>
    void FixedUpdate()
    {
        if (GameManager.Instance.gameOver == false) // If the run currently isn't over
        {
            runDistanceTravelled += (runspeed * 1.5f) * (Time.deltaTime);
            //Debug.Log(runDistanceTravelled % 10);
                runspeed += (0.75f) * Time.deltaTime;
                speed = (runspeed / 2);

            Debug.Log("Run Distance: " + (int)runDistanceTravelled + " % 10 =" + (int)runDistanceTravelled % 10);

            //if ((int)runDistanceTravelled % 500 == 0)
            //{
            //    speed += 0.5f;
            //}

            transform.up = Vector3.MoveTowards(transform.up, faceDirection, rotateSpeed * Time.deltaTime);

            Debug.Log(runDistanceTravelled);

            // If the player clicks the left mouse button (or taps the touchscreen on mobile), and the player is currently below the maximum height
            if (player.transform.position.y < maxPosition.transform.position.y && Input.GetMouseButton(0))
            {
                //if (counter <= 15)
                //{
                //    counter += 1;
                //}
                // Move the player UP.
                counter = 12;
                player.transform.position += Vector3.up * counter * Time.deltaTime;

                faceDirection = (new Vector3(1, rotateAngle, 0)).normalized;

            }

        }
        // If the player releases the left mouse button (or stops tapping the touchscreen on mobile), and the player is currently above the minimum height
        if (player.transform.position.y > (floorPosition.position.y + 0.1f) && !Input.GetMouseButton(0))
        {
            //if (counter > 0)
            //{
            //    counter -= 0.31f;
            //}
            // Move the player down, almost like GRAVITY.
            faceDirection = (new Vector3(1, -rotateAngle, 0)).normalized;
            counter = 7;
            player.transform.position += Vector3.down * counter * Time.deltaTime; //(speed / 1.8f) * Time.deltaTime;
        }

        if (player.transform.position.y <= ((floorPosition.transform.position.y ) + 0.1f))
        {
            counter = 0;
            if (!Input.GetMouseButton(0))
            {
                faceDirection = (new Vector3(1, 0, 0)).normalized;
            }
        }
    }
}
