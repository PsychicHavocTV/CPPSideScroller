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

    public float counter = 0;
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
            return;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.gameOver == false) // If the run currently isn't over
        {
            runDistanceTravelled += (runspeed) * (Time.deltaTime);
            //Debug.Log(runDistanceTravelled % 10);
            if (runspeed < 120f)
            {
                runspeed += (0.58f) * Time.deltaTime;
                speed = runspeed;
            }
            else if (runspeed > 120f)
            {
                runspeed = 120f;
            }

            Debug.Log("Run Distance: " + (int)runDistanceTravelled + " % 10 =" + (int)runDistanceTravelled % 10);

            //if ((int)runDistanceTravelled % 500 == 0)
            //{
            //    speed += 0.5f;
            //}

            Debug.Log(runDistanceTravelled);

            // If the player clicks the left mouse button (or taps the touchscreen on mobile), and the player is currently below the maximum height
            if (player.transform.position.y < maxPosition.transform.position.y && Input.GetMouseButton(0))
            {
                if (counter <= 15)
                {
                    counter += 1;
                }
                // Move the player UP.
                player.transform.position += Vector3.up * counter * Time.deltaTime;

            }
            
            // If the player releases the left mouse button (or stops tapping the touchscreen on mobile), and the player is currently above the minimum height
            if (player.transform.position.y > (floorPosition.position.y) && !Input.GetMouseButton(0))
            {
                if (counter > 0)
                {
                    counter -= 0.25f;
                }
                // Move the player down, almost like GRAVITY.
                player.transform.position += Vector3.down * counter * Time.deltaTime; //(speed / 1.8f) * Time.deltaTime;
            }

            if (player.transform.position.y <= floorPosition.transform.position.y)
            {
                counter = 0;
            }
        }
    }
}
