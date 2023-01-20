using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int gameScore;
    public TextMeshPro gameScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addScore)
    {
        gameScore += addScore;
        gameScoreText.text = gameScore.ToString();
    }

    public void ClearScore()
    {
        gameScore = 0;
        gameScoreText.text = gameScore.ToString();
    }
}
