using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreFileManager : MonoBehaviour
{
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

    public List<string> ReadScores()
    {
        List<string> storedScores = new List<string>();

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Bee Adventurous", "game-scores.txt");
        if (File.Exists(path))
        {
            foreach (string line in File.ReadLines(path))
            {
                storedScores.Add(line);
                Debug.Log(line);
            }
        }
        else
        {
            Debug.Log("ScoreFileManager.ReadScores(): scores not found");
        }


        return storedScores;
    }
}
