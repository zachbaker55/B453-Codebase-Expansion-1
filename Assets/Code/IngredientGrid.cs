using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGrid : MonoBehaviour
{
    Ingredient[] ingredients;
    // Start is called before the first frame update
    void Start()
    {
        ingredients = GetComponentsInChildren<Ingredient>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearTicks()
    {
        for(var i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].ClearTicks();
        }
    }
}
