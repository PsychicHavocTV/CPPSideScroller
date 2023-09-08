using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = new GameManager();

    public bool playerRunning = false;
    public bool gameOver = false;
    public bool gameSaved = false;
    public int totalCurrency = 0;
    public float oldBest = 0;
    public float bestRunDistance = 0;
    public float travelledRunDistance = 0;
    public int coinsCollected = 0;
    public float runDistance = 0;

    private void Start()
    {
        CheckForSave();
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
    }

    public void StartRun()
    {
        SceneManager.LoadSceneAsync("Run", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void SwimAgain()
    {
        SceneManager.UnloadSceneAsync("Run");
        SceneManager.LoadSceneAsync("Run", LoadSceneMode.Additive);
        GameManager.Instance.ResetRunStats();
    }

    public void ResetRunStats()
    {
        gameOver = false;
        gameSaved = false;
        travelledRunDistance = 0;
        coinsCollected = 0;
        runDistance = 0;
    }

    // Check for existing save data.
    public void CheckForSave()
    {
        int lineNumber = 0;
        string path = Application.persistentDataPath + "/GameData.txt"; // The file path for the save data. the file should end up in '/AppData/LocalLow/DefaultCompany/SideScroller/'
        Debug.Log(path);
        if (File.Exists(path) || File.Exists(Application.persistentDataPath + "/filesGameData.txt"))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                // Read the first line of the text file to get the total collected coins.
                for (int i = 0; i <= lineNumber; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                string lineContents = sr.ReadLine();
                                int.TryParse(lineContents, out totalCurrency);
                                Debug.Log("Total Coins Collected: " + totalCurrency);
                                break;
                            }
                        //case 1:
                        //    {
                        //        string lineContents = sr.ReadLine();
                        //        float.TryParse(lineContents, out bestRunDistance);
                        //        Debug.Log("Best Run Distance: " + bestRunDistance);
                        //        break;
                        //    }
                    }
                }
            }
        }
    }

    // Save the game data.
    public void SaveRunData(int earntCoins, float runDistance)
    {
        coinsCollected = earntCoins;
        travelledRunDistance = runDistance;

        Debug.Log("Saving...");
        Debug.Log("Coins Earned This Run: " + earntCoins);


        // Check for an existing save.
        CheckForSave();


        if (runDistance > bestRunDistance)
        {
            oldBest = bestRunDistance;
            Debug.Log("Old Best Run Distance: " + oldBest);
            bestRunDistance = runDistance;
            Debug.Log("New Best Run Distance: " + bestRunDistance);
        }
        else
        {
            Debug.Log("Best Run Distance: " + bestRunDistance);
        }

        Debug.Log("Old Total Coins Owned: " + totalCurrency);

        // Increase the total amount of coins collected by the amount of coins earned in this run.
        totalCurrency += earntCoins;

        Debug.Log("New Total Coins Owned: " + totalCurrency);

        string path = Application.persistentDataPath + "/GameData.txt"; // Save File Path.
        StreamWriter w = new StreamWriter(path);
        Debug.Log(totalCurrency);
        w.WriteLine(totalCurrency);
        if (runDistance > oldBest)
        {
            w.WriteLine(bestRunDistance);
        }
        w.Close();
        gameSaved = true;

        Debug.Log("Game Data Saved!");

        Debug.Log(travelledRunDistance);
        Debug.Log(coinsCollected);
    }

    public static GameManager Instance
    {
        get { return instance; }
    }
}
