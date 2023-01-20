using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Flip", 0.1f + (Random.value * 0.25f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        Vector3 newscale = this.transform.localScale;
        newscale.x *= -1f;
        this.transform.localScale = newscale;
        Invoke("Flip", 0.1f + (Random.value * 0.25f));
    }

}
