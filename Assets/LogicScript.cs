using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isAlive;

    private void Start()
    {
        isAlive = true;
    }

    [ContextMenu("increase score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isAlive = true;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isAlive = false;
    }

     public void QuitGame()
    {
        Application.Quit();
    }
}
