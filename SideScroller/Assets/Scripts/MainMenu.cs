using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI totalCurrencyText;

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
}
