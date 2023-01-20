using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{

    public MooseButton button;

    // Start is called before the first frame update
    void Start()
    {
        button.MouseAction = Quit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Quit()
    {
        Application.Quit();
    }
}
