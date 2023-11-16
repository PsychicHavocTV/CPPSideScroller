using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    private CurrencyEarnt currency;
    private PlayerController player;

    void Update()
    {
        if (currency == null)
        {
            currency = GetComponentInChildren<CurrencyEarnt>();
        }
        if (player == null)
        {
            player = GetComponentInChildren<PlayerController>();
        }

        // If the players run has ended and the game has not yet saved from this run
        if (GameManager.Instance.gameOver == true && GameManager.Instance.gameSaved == false)
        {
            // Save the game data.
            GameManager.Instance.SaveRunData(currency.earntRunCurrency, player.runDistanceTravelled);
        }
    }
}
