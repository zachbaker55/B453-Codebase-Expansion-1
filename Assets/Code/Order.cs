using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Order : MonoBehaviour
{
    public Ghost ghost;
    public int RequiredValue;
    public List<OrderRequirement> Requirements = new List<OrderRequirement>();
    public MooseButton button;
    public AudioSource Audio;
    public SoupPot soup;
    public AudioClip SuccessSound;
    public AudioClip FailureSound;
    public AudioClip ErrorSound;
    public AudioClip MouseOverSound;
    public AudioClip ClickSound;
    public List<Sprite> PotSprites;
    public Sprite RequiredSprite;
    public Sprite RestrictedSprite;
    public Sprite HeavenlySprite;
    public Sprite HellishSprite;
    public Sprite EmptySprite;

    public SpriteRenderer GoodEvil1;
    public SpriteRenderer GoodEvil2;
    public SpriteRenderer GoodEvil3;
    public SpriteRenderer IngredientRenderer;
    public SpriteRenderer Restriction;
    public SpriteRenderer IngredientCountRenderer;
    public TextMeshPro IngredientCountText;

    public float zoom;

    // Start is called before the first frame update
    void Start()
    {
        if (MouseOverSound != null)
        {
            button.MouseOverClip = MouseOverSound;
        }
        if (ClickSound != null)
        {
            button.MouseClickClip = ClickSound;
        }
        button.MouseAction = FillOrder;
    }

    // Update is called once per frame
    void Update()
    {
        button.OverAction = OrderEnter;
        button.OutAction = OrderExit;
    }

    void OrderEnter()
    {
        if (zoom == 0f) zoom = 0.1f;
        transform.localScale += new Vector3(zoom, zoom, zoom);
    }

    void OrderExit()
    {
        if (zoom == 0) zoom = 0.1f;
        transform.localScale -= new Vector3(zoom, zoom, zoom);
    }

    public void CreateRequirements()
    {
        float RequirementsSelector = Random.value;
        var req = new OrderRequirement();
        req.GoodnessScore =  ((int)(UnityEngine.Random.value * 7f))-3;
        if(req.GoodnessScore == 0 && SharedData.Level == 1)
        {
            req.GoodnessScore = 1;
        }
        req.Required = true;
        Requirements.Add(req);
        if (SharedData.Level == 2 || (SharedData.Level > 3 && RequirementsSelector < 0.66f))
        {
            var req2 = new OrderRequirement();
            req2.ingredient = soup.PossibleIngredients[(int)(UnityEngine.Random.value * (float)soup.PossibleIngredients.Count)];
            if (Random.value < 0.5f)
            {
                req2.Restricted = true;
            }
            else
            {
                req2.Required = true;
            }
            Requirements.Add(req2);
        }
        else
        {
            Requirements.Add(new OrderRequirement());
        }

        if (SharedData.Level == 3 || (SharedData.Level == 4 && RequirementsSelector > 0.66f) || (SharedData.Level > 4 && RequirementsSelector > 0.33f))
        {
            var req3 = new OrderRequirement();
            req3.ingredientCount = 1 + (int)(Random.value * 3f);
            //Stop us from creating any one-ingredient orders if we have added an ingredient restriction
            if(SharedData.Level > 3 && RequirementsSelector < 0.66f){
                    req3.ingredientCount = 3;
            }
            if (Random.value < 0.5f)
            {
                req3.Restricted = true;
            }
            else
            {
                req3.Required = true;
            }
            Requirements.Add(req3);
        }
        else
        {
            Requirements.Add(new OrderRequirement());
        }
        UpdateIcons();
    }

    public void UpdateIcons()
    {
        Sprite face = HeavenlySprite;
        if(Requirements[0].GoodnessScore < 0)
        {
            face = HellishSprite;
        }
        GoodEvil1.sprite = EmptySprite;
        GoodEvil2.sprite = EmptySprite;
        GoodEvil3.sprite = EmptySprite;
        if (Mathf.Abs(Requirements[0].GoodnessScore) > 0f)
        {
            GoodEvil1.sprite = face;
        }
        if (Mathf.Abs(Requirements[0].GoodnessScore) > 1f)
        {
            GoodEvil2.sprite = face;
        }
        if (Mathf.Abs(Requirements[0].GoodnessScore) > 2f)
        {
            GoodEvil3.sprite = face;
        }
        if(Requirements[1].ingredient != null)
        {
            IngredientRenderer.sprite = Requirements[1].ingredient.sprite;
            if (Requirements[1].Required)
            {
                Restriction.sprite = RequiredSprite;
            }
            else
            {
                Restriction.sprite = RestrictedSprite;
            }
        }
        else
        {
            IngredientRenderer.enabled = false;
            Restriction.enabled = false;
        }
        if(Requirements[2].ingredientCount > 0)
        {
            IngredientCountRenderer.sprite = PotSprites[Requirements[2].ingredientCount - 1];
            IngredientCountText.text = "Min";
            if (Requirements[2].Restricted)
            {
                IngredientCountText.text = "Max";
            }
        }
        else
        {
            IngredientCountRenderer.enabled = false;
            IngredientCountText.text = string.Empty;
        }
    }

    public void FillOrder()
    {
        if (!soup.boiling)
        {
            if (Audio != null && ErrorSound != null)
            {
                Audio.PlayOneShot(ErrorSound);
            }
            return;
        }
        for(int i = 0; i< Requirements.Count; i++)
        {
            if (!Requirements[i].Evaluate(soup))
            {
                if (Audio != null && FailureSound != null)
                {
                    Audio.PlayOneShot(FailureSound);
                }
                Debug.Log("Requirement Failed - ghost angry");
                ghost.Mutter();
                return;
            }
        }
        if (Audio != null && SuccessSound != null)
        {
            Audio.PlayOneShot(SuccessSound);
            Invoke("RemoveMe", 0.75f);
            this.transform.position = this.transform.position + Vector3.up*500f;
        }
        Debug.Log("All Requirements Passed - Ghost is happy!");
        if(ghost != null)
        {
            ghost.GetServed();
        }
    }

    void RemoveMe()
    {
        Destroy(this.gameObject);
    }

}
