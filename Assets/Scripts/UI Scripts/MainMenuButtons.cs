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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonPressed()
    {
        Debug.Log("main menu buttons: play button pressed");
        gameStateController.UpdateGameState(GameStateController.GameState.Play);
    }
}
