using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilMeter : MonoBehaviour
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
        newPos.y = -1.4f + (soup.currentTime * 0.28f);

        marker.transform.localPosition = newPos;
    }
}
