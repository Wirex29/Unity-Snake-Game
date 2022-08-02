using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private string scoreValue = "Score";

    private void OnApplicationQuit()
    {
        savePrefs();
    }

    public void savePrefs()
    {
        var score = Snake.getMaxScore();
        if (getPref(scoreValue) > 0 && getPref(scoreValue) < score)
        {
            PlayerPrefs.SetInt(scoreValue, score);
            PlayerPrefs.Save();
        }

    }

    public static int getPref(string keyValue)
    {
        return PlayerPrefs.GetInt(keyValue, 0);

    }

    public static void setPref(string keyName, int keyValue )
    {
        PlayerPrefs.SetInt(keyName, keyValue);

    }
}