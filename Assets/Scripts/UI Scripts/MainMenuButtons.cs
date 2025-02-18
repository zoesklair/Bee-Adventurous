using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    GameStateController gameStateController;
    private void Awake()
    {
        gameStateController = GameObject.Find("GameStateController").GetComponent<GameStateController>();
    }
    public void PlayButtonPressed()
    {
        gameStateController.UpdateGameState(GameStateController.GameState.Play);
    }
    public void BackButtonPressed()
    {
        if(gameStateController.CurrentGameState == GameStateController.GameState.Play)
        {
            gameStateController.RestartGame();
        }
        else
        {
            gameStateController.UpdateGameState(GameStateController.GameState.MainMenu);
        }
    }
    public void ScoreBoardButtonPressed()
    {
        gameStateController.UpdateGameState(GameStateController.GameState.ScoreBoard);
    }
    public void RestartButtonPressed()
    {
        gameStateController.RestartGame();
    }
}
