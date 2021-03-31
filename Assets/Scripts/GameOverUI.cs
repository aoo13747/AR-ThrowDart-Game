using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Text scoreText;
    public DragToShootScript dragToShoot;
    private void OnEnable()
    {
        Time.timeScale = 0;
        scoreText.text = "" + PlayerStat.score.ToString();
        dragToShoot.enabled = false;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        dragToShoot.enabled = true; ;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
