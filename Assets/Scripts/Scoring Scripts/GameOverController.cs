using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    GameOverScreen gameOverScreen;
    AudioSource audioSource;

    private void Awake()
    {
        gameOverScreen = gameOverPanel.GetComponent<GameOverScreen>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void SetGameOver()
    {
        Debug.Log("game over");
        PlayGameOverSound();
        gameOverScreen.MakeGameOverPanelActive();
        Time.timeScale = 0;
    }

    void PlayGameOverSound()
    {
        audioSource.Play();
    }
}
