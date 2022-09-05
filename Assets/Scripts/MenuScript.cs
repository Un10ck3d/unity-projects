using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class MenuScript : MonoBehaviour
{
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject exitButton;
    public GameObject goBackButton;
    public void startGame() {
        AnalyticsService.Instance.CustomData("MenuExit", new Dictionary<string, object>(){
            {"userCountry", "DK"}
        });
        AnalyticsService.Instance.Flush();
        SceneManager.LoadScene("GameScene");
    }
    public void exitGame() {
        Application.Quit(); 
    }
    public void gameSettings() {
        startButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);
        goBackButton.SetActive(true);
        Debug.Log("Settings Loaded");
    }
    public void goBack() {
        SceneManager.LoadScene("MenuScene");
    }
}
