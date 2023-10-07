using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunUIController : MonoBehaviour
{
    public PlayerController pC;

    public TextMeshProUGUI distanceCounterText;
    public TextMeshProUGUI coinCounterText;

    int roundedDistance = 0;


    // Update is called once per frame
    void Update()
    {
        if (roundedDistance != (int)pC.runDistanceTravelled)
        {
            roundedDistance = (int)pC.runDistanceTravelled;
        }

        //if (GameManager.Instance.gameOver == false)
        //{
            distanceCounterText.text = roundedDistance.ToString() + " METERS";
            coinCounterText.text = "$" + pC.currency.earntRunCurrency.ToString();
        //}
    }
}
