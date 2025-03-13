using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ScoreFileManager : MonoBehaviour
{
    int numberOfScoresToShow = 10;

    void UpdateScoreFile(List<string> scores)
    {
        //rewrite score file with current top scores

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Bee Adventurous");
        Directory.CreateDirectory(path);
        //file to store scores
        path = Path.Combine(path, "game-scores.txt");
        //clear and rewrite scores to file
        File.WriteAllText(path, string.Empty);
        StreamWriter writer = new StreamWriter(path, true);
        foreach (string scoreLine in scores)
        {
            writer.WriteLine(scoreLine);
        }
        writer.Close();
    }

    public void WriteScoreToFile(string scoreEntry)
    {
        //where scores are saved
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Bee Adventurous");
        Directory.CreateDirectory(path);
        //file to store scores
        path = Path.Combine(path, "game-scores.txt");
        //write score to file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(scoreEntry);
        writer.Close();
    }

    public List<string> ReadScoresIntoOrderAndTrim()
    {
        List<string> storedScores = new List<string>();

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Bee Adventurous", "game-scores.txt");
        if (File.Exists(path))
        {
            foreach (string line in File.ReadLines(path))
            {
                storedScores.Add(line);
            }
        }
        else
        {
            Debug.Log("ScoreFileManager.ReadScores(): scores not found");
        }

        storedScores.Sort(GetScoreValueFromString);
        if (storedScores.Count > numberOfScoresToShow)
        {
            storedScores = storedScores.GetRange(0, numberOfScoresToShow);
        }

        UpdateScoreFile(storedScores);

        return storedScores;
    }


    static int GetScoreValueFromString(string line1, string line2)
    {
        string score1 = line1.Split(",")[1];
        string score2 = line2.Split(",")[1];

        if(!int.TryParse(score1, out int scoreVal1))
        {
            scoreVal1 = -1;
        }
        if(!int.TryParse(score2, out int scoreVal2))
        {
            scoreVal2 = -1;
        }

        if(scoreVal1 < scoreVal2)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
