using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resetScore : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public void resetTheScore() {
        PlayerPrefs.SetFloat("highscore", 999f);
        highscoreText.text = "Highscore: " + 999f;   
    }
}
