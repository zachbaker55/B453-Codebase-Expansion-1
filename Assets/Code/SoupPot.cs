using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupPot : MonoBehaviour
{

    public List<Ingredient> PossibleIngredients;
    public float CurrentGoodness = 0;
    public List<Ingredient> Ingredients = new List<Ingredient>();
    public AudioSource Audio;
    public AudioClip BoilingSound;
    public AudioClip SplashSound;
    public float StartTime;
    public float TimetoBoil; 
    public float EachIngredientTime;
    public float NewPotTime;
    public bool boiling = false;
    public SpriteRenderer PotRenderer;
    public List<Sprite> PotSprites;
    public SpriteRenderer FireRenderer;
    public bool LevelStarted = false;
    public SpriteRenderer BoilingRenderer;
    public Flicker bubbles;

    // Start is called before the first frame update
    void Start()
    {

        if (Audio.isPlaying)
        {
            Audio.Stop();
        }
        Audio.loop = true;
        Audio.clip = BoilingSound;
    }

    public void StartLevel()
    {
        StartTime = Time.time;
        TimetoBoil = NewPotTime;
        LevelStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelStarted)
        {
            return;
        }
        UpdateBubbling();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);

        //Do new ingredients increase the time needed to boil?
        TimetoBoil += EachIngredientTime;

        Audio.PlayOneShot(SplashSound);

        Debug.Log("Just Added Ingredient number " + Ingredients.Count);

        if (ingredient.IsNeutral)
        {
            float valueToSubtract = ingredient.Goodness;
            if(Math.Abs(CurrentGoodness) != CurrentGoodness)
            {
                valueToSubtract *= -1f;
            }
            if(Math.Abs(valueToSubtract) > Math.Abs(CurrentGoodness))
            {
                valueToSubtract = CurrentGoodness;
            }
            CurrentGoodness -= valueToSubtract;
        }
        else
        {
            CurrentGoodness += ingredient.Goodness;
        }
        if(CurrentGoodness < -3f)
        {
            CurrentGoodness = -3f;
        }
        if(CurrentGoodness > 3f)
        {
            CurrentGoodness = 3f;
        }
        Debug.Log("Current Goodness is " + CurrentGoodness);

    }

    public void UpdateBubbling()
    {
        //Timer for soup bubbling
        if (Time.time > StartTime + TimetoBoil)
        {
            //boilin
            //Debug.Log("boilin");
            boiling = true;
            TimetoBoil = 0;
            StartTime = Time.time;
            Audio.clip = BoilingSound;
            if (!Audio.isPlaying) Audio.Play();
        }
        else
        {
            //Debug.Log("not boilin");
            boiling = false;
            Audio.clip = null;
        }

        BoilingRenderer.enabled = boiling;

    }

    public void Dump()
    {
        PotRenderer.sprite = PotSprites[1];
        FireRenderer.enabled = false;
        Invoke("RightYourself", 0.5f);
    }

    public void RightYourself()
    {
        FireRenderer.enabled = true;
        PotRenderer.sprite = PotSprites[0];
    }

}
