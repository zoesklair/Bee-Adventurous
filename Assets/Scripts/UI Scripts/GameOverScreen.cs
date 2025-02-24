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
    ScoreFileManager scoreFileManager;
    private void Awake()
    {
        gameObject.SetActive(false);
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        scoreFileManager = GameObject.Find("ScoreController").GetComponent<ScoreFileManager>();
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

        string scoreEntry = playerName + ", " + scoreController.Score;
        Debug.Log("GameOverScreen.SavePlayerNameAndScore: save " + scoreEntry);
        scoreFileManager.WriteScoreToFile(scoreEntry);
    }
}
