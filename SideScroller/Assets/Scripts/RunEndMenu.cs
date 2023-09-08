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

    public Button mainMenuButton;

    public GameObject endRunMenu;

    bool endRunMenuLoaded = false;

    public float travelDistanceTotal = 0;
    public float travelDistanceCurrent = 0;
    public int earntCoinsTotal = 0;
    public int earntCoinsCurrent = 0;

    public void OpenMainMenuScene()
    {
        SceneManager.LoadSceneAsync(2);
        SceneManager.UnloadSceneAsync(0);
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
            if (earntCoinsTotal != GameManager.Instance.coinsCollected)
            {
                earntCoinsTotal = GameManager.Instance.coinsCollected;
            }
            if (travelDistanceTotal != GameManager.Instance.travelledRunDistance)
            {
                travelDistanceTotal = GameManager.Instance.travelledRunDistance;
            }

            int travelDistanceRounded = (int)travelDistanceTotal;

            distanceText.text = travelDistanceRounded.ToString() + " Meters!";
            collectedText.text = earntCoinsTotal.ToString();
        }
    }
}
