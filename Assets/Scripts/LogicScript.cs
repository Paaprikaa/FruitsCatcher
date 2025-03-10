using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public bool isAlive;
    public GameObject gameOverUI;
    public GameObject gameOverBackground;
    public GameObject pauseUI;
    public GameObject pauseBackground;
    public AudioManagerScript audioManager;
    public TopScoresScript topScores;
    private float hitPitch;

    private void Start()
    {
        isAlive = true;
        hitPitch = 1.0f;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseUI.activeSelf)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseUI.activeSelf)
        {
            ResumeGame();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioManager.Play("hit", 1.0f, hitPitch);
        hitPitch = hitPitch + 0.2f;
        if (hitPitch >= 1.8f) hitPitch = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Game over menu //
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameOverBackground.SetActive(true);
        isAlive = false;
        topScores.AddScore(playerScore);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isAlive = true;
    }
    public void ScoreGame()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    // Pause menu //
    public void PauseGame()
    {
        pauseUI.SetActive(true);
        pauseBackground.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        pauseBackground.SetActive(false);
        Time.timeScale = 1f;
    }
}
