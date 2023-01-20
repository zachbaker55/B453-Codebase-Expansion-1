

using System.Collections.Generic;
using UnityEngine;

public class OrderRequirement
{

    public string Description;

    public Ingredient ingredient;
    public int ingredientCount;
    public int GoodnessScore = -1000;

    public bool Required;
    public bool Restricted;


    public bool Evaluate(SoupPot soup)
    {
        if(GoodnessScore != -1000)
        {
            Debug.Log("Checking if the Soup's goodness of " + soup.CurrentGoodness + " matches " + GoodnessScore);
            return GoodnessScore == soup.CurrentGoodness;
        }
        if(ingredientCount != 0)
        {
            if (Required)
            {
                Debug.Log("Checking That soup contains at least " + ingredientCount + " ingredients");
                return ingredientCount <= soup.Ingredients.Count;
            }
            else if (Restricted)
            {
                Debug.Log("Checking That soup contains no more than " + ingredientCount + " ingredients");
                return ingredientCount >= soup.Ingredients.Count;
            }
        }
        if(ingredient != null)
        {
            if (Required)
            {
                Debug.Log("Checking That soup contains " + ingredient);
                return soup.Ingredients.Contains(ingredient);
            }
            if (Restricted)
            {
                Debug.Log("Checking That soup does not contain " + ingredient);
                return !soup.Ingredients.Contains(ingredient);
            }
        }
        Debug.Log("Default evaluation - True");
        return true;
    }

}