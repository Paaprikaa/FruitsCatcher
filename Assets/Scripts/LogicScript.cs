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

    [ContextMenu("increase score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioManager.Play("hit", 1.0f, hitPitch);
        hitPitch = hitPitch + 0.2f;
        if (hitPitch >= 1.8f) hitPitch = 1.0f;

    }

    // Hover button effect
    public void enterButton(GameObject effect)
    {
        audioManager.Play("circle", 1.0f, 1.0f);
        effect.SetActive(true);
    }
    public void exitButton(GameObject effect)
    {
        effect.SetActive(false);
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
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isAlive = true;
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
