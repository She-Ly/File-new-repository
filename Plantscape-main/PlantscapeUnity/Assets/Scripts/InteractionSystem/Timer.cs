using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool isTimerActive = false;

    void Start()
    {
        // Initialize the timer but don't start it yet
        remainingTime = 300; // Adjust this to your initial timer value
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isTimerActive && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            // Game over logic here
            GameOver("GameOver");
            timerText.color = Color.red;
            isTimerActive = false;
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isTimerActive = true;
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }

    public void StopAndResetTimer()
    {
        isTimerActive = false;
        remainingTime = 300; // Reset the timer
        UpdateTimerDisplay(); // Update the timer display to show 00:00
    }

    public void GameOver(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
