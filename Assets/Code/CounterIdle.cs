using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterIdle : MonoBehaviour
{
    public Sprite[] Frames;
    public float frametime;
    float timer;
    public SpriteRenderer spriteRenderer;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > frametime)
        {
            timer = timer - frametime;
            i++;
            if (i >= Frames.Length) i = 0;
            //Debug.Log("i = " + i);
            if(Frames != null) spriteRenderer.sprite = Frames[i];
        }
    }
}
