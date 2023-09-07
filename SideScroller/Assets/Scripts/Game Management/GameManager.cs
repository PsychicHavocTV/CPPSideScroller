using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = new GameManager();

    public bool playerRunning = false;
    public bool gameOver = false;
    public bool gameSaved = false;
    public int totalCurrency = 0;
    public int bestRunDistance = 0;

    public float travelledRunDistance = 0;

    private void Start()
    {
        CheckForSave();
    }

    // Check for existing save data.
    private void CheckForSave()
    {
        int lineNumber = 1;
        string path = Application.persistentDataPath + "/GameData.txt"; // The file path for the save data. the file should end up in '/AppData/LocalLow/DefaultCompany/SideScroller/'
        if (File.Exists(path))
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
                        case 1:
                            {
                                string lineContents = sr.ReadLine();
                                int.TryParse(lineContents, out bestRunDistance);
                                Debug.Log("Best Run Distance: " + bestRunDistance);
                                break;
                            }
                    }
                }
            }
        }
    }

    // Save the game data.
    public void SaveRunData(int earntCoins, float runDistance)
    {
        Debug.Log("Saving...");
        Debug.Log("Coins Earned This Run: " + earntCoins);


        // Check for an existing save.
        CheckForSave();


        if (runDistance > travelledRunDistance)
        {
            Debug.Log("Old Best Run Distance: " + travelledRunDistance);
            travelledRunDistance = runDistance;
            Debug.Log("New Best Run Distance: " + travelledRunDistance);
        }
        else
        {
            Debug.Log("Best Run Distance: " + travelledRunDistance);
        }

        Debug.Log("Old Total Coins Owned: " + totalCurrency);

        // Increase the total amount of coins collected by the amount of coins earned in this run.
        totalCurrency += earntCoins;

        Debug.Log("New Total Coins Owned: " + totalCurrency);

        string path = Application.persistentDataPath + "/GameData.txt"; // Save File Path.
        StreamWriter w = new StreamWriter(path);
        Debug.Log(totalCurrency);
        w.WriteLine(totalCurrency);
        if (travelledRunDistance > bestRunDistance)
        {
            w.WriteLine(travelledRunDistance);
        }
        w.Close();
        gameSaved = true;

        Debug.Log("Game Data Saved!");
    }

    public static GameManager Instance
    {
        get { return instance; }
    }
}
