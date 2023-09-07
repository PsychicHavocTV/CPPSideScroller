using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTrigger : MonoBehaviour
{
    private CurrencyEarnt currency;
    public GameObject coinObject;

    private void Update()
    {
        if (currency == null)
        {
            currency = GetComponentInParent<CurrencyEarnt>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(coinObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
    }



}
