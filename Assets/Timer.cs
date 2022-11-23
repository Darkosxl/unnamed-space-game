using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public bool isTimerActive = false;
    private void Start()
    {
        timeText.gameObject.SetActive(false);
        // Starts the timer automatically
        //timerIsRunning = true;
    }
    void Update()
    {
        gameTimer();
        DisplayTime(timeRemaining);
    }
    public void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (timeToDisplay<10 )
        {
            timeText.text = string.Format("{0}{1:00}", minutes, seconds);
            timeText.text = timeText.text.Substring(timeText.text.Length - 1);
        }
        else
        {
            timeText.text = string.Format("{0}{1:00}", minutes, seconds);
            timeText.text = timeText.text.Substring(timeText.text.Length - 2, timeText.text.Length - 1);
        }
    }
    public void gameTimer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}