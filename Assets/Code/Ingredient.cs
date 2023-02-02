using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ingredient : MonoBehaviour
{

    public bool IsNeutral;
    public int Goodness;
    public bool AlreadyAdded;
    public Sprite sprite;
    public SpriteRenderer tick;
    public SoupPot Soup;
    public MooseButton button;
    public AudioSource Audio;
    public AudioClip MouseOverSound;
    public AudioClip ClickSound;
    public AudioClip AlreadyAddedSound;
    public int angle;
    public float zoom;

    // Start is called before the first frame update
    void Start()
    {
        if(MouseOverSound != null)
        {
            button.MouseOverClip = MouseOverSound;
        }
        if (ClickSound != null)
        {
            button.MouseClickClip = ClickSound;
        }
        button.MouseAction = AddToSoup;
    }

    // Update is called once per frame
    void Update()
    {
        button.OverAction = IngredientEnter;
        button.OutAction = IngredientExit;
    }

    void IngredientEnter()
    {
        if (Mathf.Abs(angle) > 180) angle = 90;
        if (zoom == 0f) zoom = 0.1f;
        transform.Rotate(Vector3.forward * angle);
        transform.localScale += new Vector3(zoom, zoom, zoom);

    }

    void IngredientExit()
    {
        if (Mathf.Abs(angle) > 180) angle = -90;
        if (zoom == 0f) zoom = 0.1f;
        transform.Rotate(Vector3.forward * -angle);
        transform.localScale -= new Vector3(zoom, zoom, zoom);
    }

    public void AddToSoup()
    {
        if(Soup != null)
        {
            Soup.AddIngredient(this);
            tick.enabled = true;
        }
    }

    public void ClearTicks()
    {
        tick.enabled = false; 
    }

}
