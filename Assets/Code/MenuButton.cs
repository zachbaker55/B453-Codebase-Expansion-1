using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public MooseButton button;
    public bool quitbutton;
    public bool playbutton;
    public bool levelbutton;
    public bool nextlevelbutton;
    public int level;
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        if (quitbutton)
        {
            button.MouseAction = Quit;
            //text.text = "Quit";
        }

        else if (playbutton)
        {
            button.MouseAction = Play;
            //text.text = "Play";
        }

        else if (levelbutton)
        {
            button.MouseAction = Play;
            //text.text = "Level: " + level.ToString(); 
        }

        else if (nextlevelbutton)
        {
            button.MouseAction = NextLevel;
            //text.text = "Next Level";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Quit()
    {
        Application.Quit();
    }
    void Play()
    {
        SharedData.levelWon = false;
        SharedData.Score = 0;
        if (playbutton)
        {
            SceneManager.LoadScene("MainGame");
        }

        else if (levelbutton)
        {
            SharedData.Level = level;
            SceneManager.LoadScene("MainGame");  //load level
        }
    }

    void NextLevel()
    {
        SharedData.Score = 0;
        SharedData.levelWon = false;
        SharedData.Level++;
        SceneManager.LoadScene("MainGame");  //load next level
    }    
}
