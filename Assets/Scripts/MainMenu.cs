using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highestScore;

    private void Awake()
    {
        highestScore.text = ("Highest Score: " + GameController.getPref("Score").ToString());    
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("quit");
    }


}