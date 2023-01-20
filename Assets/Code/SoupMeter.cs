using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoupMeter : MonoBehaviour
{

    public GameObject marker;
    public SoupPot soup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = marker.transform.localPosition;
        newPos.x = -0.05f + (soup.CurrentGoodness * 0.55f);

        marker.transform.localPosition = newPos;
        
    }
}
