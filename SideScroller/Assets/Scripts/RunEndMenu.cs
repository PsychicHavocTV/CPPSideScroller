using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunEndMenu : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI collectedText;

    public CurrencyEarnt currency;

    public Button mainMenuButton;

    public GameObject endRunMenu;

    bool endRunMenuLoaded = false;

    public int travelDistanceTotal = 0;
    public int travelDistanceCurrent = 0;
    public int earntCoinsTotal = 0;
    public int earntCoinsCurrent = 0;

    /// <summary>
    /// <c>OpenMainMenuScene</c> is called after a run if the 'MainMenu' button is clicked. when called, the game will load the main menu, and then will unload the run scene.
    /// </summary>
    public void OpenMainMenuScene()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Run");
    }

    public void NewRun()
    {
        endRunMenu.SetActive(false);
        GameManager.Instance.SwimAgain();
    }

    void Update()
    {
        if (endRunMenu == null)
        {
            endRunMenu = GameObject.Find("EndOfRun");
        }
        if (GameManager.Instance.gameOver == true && endRunMenuLoaded == false)
        {
            endRunMenu.SetActive(true);
            endRunMenuLoaded = true;
        }

        if (endRunMenu.activeSelf == true)
        {
            if (earntCoinsTotal != (int)GameManager.Instance.coinsCollected)
            {
                earntCoinsTotal = GameManager.Instance.coinsCollected;
            }
            if (travelDistanceTotal != (int)GameManager.Instance.travelledRunDistance)
            {
                travelDistanceTotal = (int)GameManager.Instance.travelledRunDistance;
            }

            int travelDistanceRounded = (int)travelDistanceTotal;

            distanceText.text = travelDistanceTotal.ToString() + " Meters!";
            collectedText.text = currency.earntRunCurrency.ToString();
        }
    }
}
