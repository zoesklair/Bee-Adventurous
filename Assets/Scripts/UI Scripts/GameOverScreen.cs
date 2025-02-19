using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    TMP_Text finalScoreDisplay;
    [SerializeField]
    TMP_InputField playerNameInputField;
    ScoreController scoreController;
    private void Awake()
    {
        gameObject.SetActive(false);
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }
    public void MakeGameOverPanelActive()
    {
        gameObject.SetActive(true);
        SetFinalScoreDisplay();
    }
    private void SetFinalScoreDisplay()
    {
        finalScoreDisplay.text = "Your score: " + scoreController.Score;
    }
    public void SavePlayerNameAndScore()
    {
        string playerName = playerNameInputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        Debug.Log("GameOverScreen.SavePlayerNameAndScore: save " + playerName + ", " + scoreController.Score);
    }
}
