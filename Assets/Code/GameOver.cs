using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public TextMeshPro TitleText;
    public TextMeshPro ScoreText;
    public MooseButton ContinueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (SharedData.levelWon)
        {
            if (SharedData.Level < 5)
            {
                TitleText.text = "Level " + SharedData.Level + " Complete!";
            }
            if (SharedData.Level == 5)
            {
                TitleText.text = "You're the Gumbo Master!\r\nCare to try a challenge game?";
            }
            if (SharedData.Level == 6)
            {
                Destroy(ContinueButton.gameObject);
                TitleText.text = "Impressive!  You managed to serve all 24 hungry ghosts!";
            }
            ScoreText.text = "Time Remaining:\r\n" + SharedData.TimeRemaining;
        }
        else
        {
            ScoreText.text = "Your Score:\r\n" + SharedData.Score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
