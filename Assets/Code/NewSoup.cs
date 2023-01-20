using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSoup : MonoBehaviour
{

    public SoupPot soup;
    public AudioSource Audio;
    public AudioClip DumpSound;
    public MooseButton button;

    // Start is called before the first frame update
    void Start()
    {
        button.MouseAction = DumpSoup;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DumpSoup()
    {
        //Clear soup pot list Ingredients
        soup.Ingredients = new List<Ingredient>();

        //Clear souppot CurrentGoodness
        soup.CurrentGoodness = 0;

        //Play sound
        Audio.PlayOneShot(DumpSound);

        //Refresh art
        //TODO

        //Update time to boil
        soup.StartTime = Time.time;
        soup.TimetoBoil = soup.NewPotTime;
        soup.boiling = false;
        soup.Dump();
    }

}
