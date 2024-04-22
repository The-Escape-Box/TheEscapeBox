using System;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    
    public static StatTracker Instance;

    public int currentScene = 1;

    private int _firstMapKillCount = 0;
    private float _firstMapTime = 0;
    
    private int _secondMapKillCount = 0;
    private float _secondMapTime = 0;

    private bool firstMapDone = false;
    private bool secondMapDone = false;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseKillCountByOne()
    {
        if (Instance.currentScene == 2)
        {
            Instance._firstMapKillCount++;
        }
        if (Instance.currentScene == 4)
        {
            Instance._secondMapKillCount++;
        }
    }

    public void OnSceneChangeTo(int scene)
    {
        Instance.currentScene = scene;
        if (Instance.currentScene == 3)
        {
            Instance._firstMapTime = Time.timeSinceLevelLoad;
            firstMapDone = true;
        }
        if (Instance.currentScene == 5)
        {
            Instance._secondMapTime = Time.timeSinceLevelLoad;
            secondMapDone = true;
        }        
        if (Instance.currentScene == 6)
        {
            if (firstMapDone)
            { 
                Instance._secondMapTime = Time.timeSinceLevelLoad;
            }
            else
            {
                Instance._firstMapTime = Time.timeSinceLevelLoad;
            }
        }
    }

    public void ShowStats(StatAnzeige anzeige)
    {
            anzeige.firstTime.text = "Time for first map: " + Mathf.Ceil(_firstMapTime) + " seconds";
            anzeige.firstKills.text = "Kills on first map: " + _firstMapKillCount;
            anzeige.secondTime.text = "Time for second map: " + Mathf.Ceil(_secondMapTime) + " seconds";
            anzeige.secondKills.text = "Kills on second map: " +_secondMapKillCount;
            anzeige.info.text = "Please share this information with us!";
    }
}
