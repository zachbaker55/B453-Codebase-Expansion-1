
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public MooseButton button;

    // Start is called before the first frame update
    void Start()
    {
        button.MouseAction = Play;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Play()
    {
        SceneManager.LoadScene("MainGame");
    }
}
