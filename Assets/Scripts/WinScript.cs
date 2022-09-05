using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WinScript : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI timerObject;
    public float score;
    bool won = false;

    void Start() {
        won = false;
        score = 0;
        /*PlayerPrefs.SetFloat("highscore", 100f);*/
        float oldHighscore = PlayerPrefs.GetFloat("highscore", 999f);
        highscoreText.text = "Highscore: " + oldHighscore;
    }

    void Update()
    {
        if (!won) {
            score = Time.timeSinceLevelLoad;
            timerObject.text = $"Time: {Math.Floor(score * 10f) / 10f} seconds";
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player" && won == false) {
            Debug.Log("Won!");
            won = true;
            timerObject.text = "You didnt beat your highscore :( " + score;
            float oldHighscore = PlayerPrefs.GetFloat("highscore", 999f);
            if (oldHighscore > score) {
                PlayerPrefs.SetFloat("highscore", score);
                timerObject.text = "You beat your highscore!!\nYour score was: " + score;
                highscoreText.text = "Highscore: " + score;
            }
        }
    }
}
