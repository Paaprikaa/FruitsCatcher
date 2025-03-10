using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMenuScript : MonoBehaviour
{
    public TopScoresScript topScoresScript;
    [SerializeField]
    public List<Text> scores;

    private void Start()
    {
        for (int i = 0; i < topScoresScript.topScores.Count; i++)
        {
            if (topScoresScript.topScores[i] != 0)
                scores[i].text = topScoresScript.topScores[i].ToString();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MenuGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
