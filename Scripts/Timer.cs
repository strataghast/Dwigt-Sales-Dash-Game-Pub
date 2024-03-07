using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0) // If the remaining time is greater than 0, then the timer will continue to count down.
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0) // If the remaining time is less than or equal to 0, then the timer will stop and the game will end.
        {
            remainingTime = 0;
            timerText.color = Color.red; // The timer will turn red to indicate that time has expired.
            GameOver(); // This will call the GameOver function.
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

    void GameOver()
    {
        SceneManager.LoadScene("End Menu"); // This will load the end menu scene upon expiration of the timer (scores will be saved).
    }
}
