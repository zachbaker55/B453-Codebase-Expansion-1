using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopOver : MonoBehaviour
{
    public MooseButton button;
    public TextMeshPro text;
    public System.Action callback;

    // Start is called before the first frame update
    void Start()
    {
        button.MouseAction = ClickFunction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickFunction()
    {
        if(callback != null)
        {
            callback();
        }
        Destroy(this.gameObject);
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }

}
