using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSoup : MonoBehaviour
{

    public SoupPot soup;
    public IngredientGrid ingredientGrid;
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

        //Clear soup ticks
        ingredientGrid.ClearTicks();

        //Play sound
        Audio.PlayOneShot(DumpSound);

        //Refresh art
        //TODO

        //Update time to boil
        soup.currentTime = soup.StartingTime;
        soup.boiling = false;
        soup.Dump();
    }

}
