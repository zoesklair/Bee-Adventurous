using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    ScoreFileManager scoreFileManager;
    [SerializeField]
    TMP_Text scoreTextBox;

    private void Awake()
    {
        scoreFileManager = GameObject.Find("ScoreController").GetComponent<ScoreFileManager>();
    }
    public void GetScores()
    {
        Debug.Log("get scores");
        List<string> scores = scoreFileManager.ReadScores();
        if(scores.Count > 0)
        {
            foreach(string score in scores)
            {
                scoreTextBox.text += score + "\n";
            }
        }
        else
        {
            Debug.Log("scoreboard: scores.count not > 0");
        }
        
    }
}
