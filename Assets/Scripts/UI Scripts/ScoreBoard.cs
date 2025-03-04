using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    ScoreFileManager scoreFileManager;
    [SerializeField]
    GameObject scoresContainer;

    private void Awake()
    {
        scoreFileManager = GameObject.Find("ScoreController").GetComponent<ScoreFileManager>();
    }
    public void GetScores()
    {
        List<string> scores = scoreFileManager.ReadScoresIntoOrderAndTrim();
        List<GameObject> scoreBoxEntries = new List<GameObject>();
        foreach(Transform child in scoresContainer.transform)
        {
            scoreBoxEntries.Add(child.gameObject);
        }

        if(scores.Count > 0)
        {
            for(int i = 0; i < scores.Count; i++)
            {
                TMP_Text playerText = scoreBoxEntries[i].transform.GetChild(0).GetComponent<TMP_Text>();
                string[] namescore = SplitNameAndScore(scores[i]);
                if(playerText != null)
                {
                    playerText.text = namescore[0];
                }
                TMP_Text scoreText = scoreBoxEntries[i].transform.GetChild(1).GetComponent<TMP_Text>();
                if (scoreText != null)
                {
                    scoreText.text = namescore[1];
                }

            }
        }
        else
        {
            Debug.Log("scoreboard: scores.count not > 0");
        }
        
    }
    string[] SplitNameAndScore(string nameScore)
    {
        string[] nameScoreSeparated = nameScore.Split(",");
        return nameScoreSeparated;
    }
}
