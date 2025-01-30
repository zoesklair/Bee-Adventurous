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

    private GameState currentGameState;
    public enum GameState
    {
        MainMenu = 0,
        ScoreBoard = 1,
        Play = 2
    }
    void Awake()
    {
        currentGameState = GameState.MainMenu;
        scoreBoardPanel.SetActive(false);
        Time.timeScale = 0;
    }


    public void UpdateGameState(GameState newGameState)
    {
        
        if(newGameState == GameState.Play)
        {
            mainMenuPanel.SetActive(false);
            Time.timeScale = 1;
            currentGameState = newGameState;
            //restart game position
        }
        else if(newGameState == GameState.MainMenu)
        {
            scoreBoardPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            Time.timeScale = 0;
            currentGameState = newGameState;
        }
    }
}
