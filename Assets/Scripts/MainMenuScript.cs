using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioManagerScript audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }
    // Hover button effect
    public void enterButton(GameObject effect)
    {
        Debug.Log("enterbutton");
        audioManager.Play("circle", 1.0f, 1.0f);
        effect.SetActive(true);
    }
    public void exitButton(GameObject effect)
    {
        Debug.Log("exitbutton");
        effect.SetActive(false);
    }

    public void PlayGame()
    {
        Debug.Log("playyyyyyyyyyyyyyyyyy");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
