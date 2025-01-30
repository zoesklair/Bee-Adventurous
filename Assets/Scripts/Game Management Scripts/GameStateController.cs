using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameState CurrentGameState => currentGameState;
    [SerializeField]
    GameObject mainMenuPanel;

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
        Time.timeScale = 0;
    }


    public void UpdateGameState(GameState newGameState)
    {
        currentGameState = newGameState;
        if(currentGameState == GameState.Play)
        {
            mainMenuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
