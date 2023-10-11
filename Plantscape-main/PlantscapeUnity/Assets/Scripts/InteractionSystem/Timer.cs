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


    public Animator animator;
    private Coroutine animCoroutine;
    public Sprite dolor, colorNormal;
    public bool looser;

    void Start()
    {

       

        // Initialize the timer but don't start it yet
        remainingTime = 10; // Adjust this to your initial timer value
        UpdateTimerDisplay();
    }

    void Update()
    {


        if (looser)
        {
            return;
        }

        if (isTimerActive && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (remainingTime <= 0)
        {
            if (animCoroutine != null)
            {
            //    StopCoroutine(animCoroutine);
            }

            if(!looser)
                animator.SetBool("isDead", true);
            
            // Start a new coroutine that waits for 6 seconds
            //animCoroutine = StartCoroutine(WaitForDeathAnim());
            StartCoroutine(WaitForDeathAnim());
            looser = true;
            remainingTime = 0;
            // Game over logic here
            timerText.color = Color.red;
            timerText.text = "0";
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
        //animator.gameObject.GetComponent<SpriteRenderer>().sprite = dolor;

    }

    public void StopTimer()
    {
        isTimerActive = false;
       // animator.gameObject.GetComponent<SpriteRenderer>().sprite = colorNormal;
    }

    public void StopAndResetTimer()
    {
        isTimerActive = false;
        remainingTime = 10; // Reset the timer
        UpdateTimerDisplay(); // Update the timer display to show 00:00
    }

    public void GameOver(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public GameObject pnlGameOver;
    private IEnumerator WaitForDeathAnim()
    {
        yield return new WaitForSeconds(3.4f);
       // GameOver("GameOver");
        pnlGameOver.SetActive(true);
    }
}
