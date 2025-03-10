using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu]

public class TopScoresScript : MonoBehaviour
{
    [System.NonSerialized]
    public List<int> topScores = new List<int>();
    private string filename = "TopScores.json";

    private void Awake()
    {
        LoadTopScores();
    }

    private void LoadTopScores()
    {
        topScores = FileHandler.ReadFromJSON<int>(filename);
        while (topScores.Count < 3)
        {
            topScores.Add(0);
        }
    }

    private void SaveTopScores()
    {
        FileHandler.SaveToJSON<int>(topScores, filename);
    }

    // if score is better than top 3, then add.
    public void AddScore(int score)
    {
        if (topScores.Contains(score)) return;

        for (int i = 0; i < topScores.Count; i++)
        {
            if (topScores[i] < score)
            {
                if (i < 2)
                {
                    if (i == 0)
                    {
                        topScores[i + 2] = topScores[i + 1];
                    }
                    topScores[i + 1] = topScores[i];
                }
                topScores[i] = score;
                SaveTopScores();
                return;
            }
        }
    }
}
