using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI totalCurrencyText;
    public TextMeshProUGUI sstotalCurrencyText;
    public TextMeshProUGUI bestTDistanceText;
    public TextMeshProUGUI totalTDistanceText;

    private void Start()
    {
        GameManager.Instance.CheckForSave();
        totalCurrencyText.text = GameManager.Instance.totalCurrency.ToString();
    }

    public void Run()
    {
        GameManager.Instance.gameOver = false;
        GameManager.Instance.gameSaved = false;
        GameManager.Instance.playerRunning = true;
        GameManager.Instance.travelledRunDistance = 0;
        GameManager.Instance.runDistance = 0;
        GameManager.Instance.coinsCollected = 0;
        GameManager.Instance.StartRun();
    }

    public void OpenShop()
    {

    }

    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void LoadPlayerStats()
    {
        int totalTDistance = (int)GameManager.Instance.totalTravelledDistance;
        int bestTDistance = (int)GameManager.Instance.bestRunDistance;
        int currencyBalance = (int)GameManager.Instance.totalCurrency;

        bestTDistanceText.text = "Best Run Distance: " + bestTDistance.ToString() + " Meters";
        totalTDistanceText.text = "Total Run Distance: " + totalTDistance.ToString() + " Meters";
        sstotalCurrencyText.text = "Player Coin Balance: $" + currencyBalance.ToString();
    }
}
