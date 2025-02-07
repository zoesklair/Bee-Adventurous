using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameState CurrentGameState => currentGameState;
    [SerializeField]
    GameObject mainMenuPanel;
    [SerializeField]
    GameObject scoreBoardPanel;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    GameObject backButton;

    GameStartup gameStartup;


    private GameState currentGameState;
    public enum GameState
    {
        MainMenu = 0,
        ScoreBoard = 1,
        Play = 2
    }
    void Awake()
    {
        gameStartup = gameObject.GetComponent<GameStartup>();
        currentGameState = GameState.MainMenu;
        scoreBoardPanel.SetActive(false);
        backButton.SetActive(false);
        Time.timeScale = 0;
    }


    public void UpdateGameState(GameState newGameState)
    {
        
        if(newGameState == GameState.Play)
        {
            mainMenuPanel.SetActive(false);
            backButton.SetActive(true);
            scoreBoardPanel.SetActive(false);
            gameOverPanel.SetActive(false);

            gameStartup.SetUpGame();
            StartCoroutine(PlayGame());

            
        }
        else if(newGameState == GameState.MainMenu)
        {
            scoreBoardPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            backButton.SetActive(false);
            Time.timeScale = 0;
        }
        else if(newGameState == GameState.ScoreBoard)
        {
            scoreBoardPanel.SetActive(true);
            gameOverPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            backButton.SetActive(true);
        }
        currentGameState = newGameState;
    }
    IEnumerator PlayGame()
    {
        yield return 0;
        Time.timeScale = 1;
    }
}
