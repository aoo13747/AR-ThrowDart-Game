using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    public float timer = 120f;

    public GameObject gameOverUI;
    public GameObject pauseUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0f, Mathf.Infinity);

        timerText.text = "Timer : " + string.Format("{0:00}", timer);
        scoreText.text = "Score : " + PlayerStat.score.ToString();

        if(timer <= 0)
        {
            gameOverUI.SetActive(true);
        }
    }
    public void PasueGame()
    {
        pauseUI.SetActive(true);
    }
}
