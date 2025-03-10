using UnityEngine;

public class HoverEffects : MonoBehaviour
{
    public AudioManagerScript audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }
    public void enterButton(GameObject effect)
    {
        audioManager.Play("circle", 1.0f, 1.0f);
        effect.SetActive(true);
    }
    public void exitButton(GameObject effect)
    {
        effect.SetActive(false);
    }

}