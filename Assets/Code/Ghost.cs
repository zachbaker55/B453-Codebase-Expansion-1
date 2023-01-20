using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public AudioClip[] GhostSounds;
    public int randGhostSound = 0;
    public Order order;
    public int QueuePosition = 0;
    public bool WalkingToCounter;
    public bool WalkingToPosition;
    public bool Leaving;
    public AudioSource Audio;
    public AudioClip ServeSound;
    public AudioClip OrderSound;
    public bool HasOrdered;
    public GameObject OrderPrefab;
    public SoupPot soup;
    public GameObject MyOrderTicket;
    public MainGame myGame;
    public SpriteRenderer SpeechBubbleRenderer;
    public SpriteRenderer GhostRenderer;
    public List<Sprite> GhostSprites;

    //ghost sine
    float frequency = 20f;
    float magnitude = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        HideSpeech();
        if (Audio.isPlaying)
        {
            Audio.Stop();
        }
            //pick randsound
            if (GhostSounds.Length != 0)
        {
            randGhostSound = Random.Range(0, GhostSounds.Length);
        }

        MoveToQueuePosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (WalkingToPosition || WalkingToCounter || Leaving)
        {
            this.transform.position = this.transform.position + (Vector3.left * 0.03f) + (Vector3.up * 0.03f) * Mathf.Sin (Time.time * frequency) * magnitude;

            //startaudio
            if (GhostSounds.Length != 0)
            {
                Audio.clip = GhostSounds[randGhostSound];
                Audio.loop = true;
                if (!Audio.isPlaying) Audio.Play();
            }

        }
        else
        {
            //stop audio
            if (GhostSounds.Length != 0)
            {
                if (Audio.isPlaying) Audio.Stop();
                Audio.loop = false;
            }
        }
        if (WalkingToPosition)
        {
            if (this.transform.position.x <= -1f + (QueuePosition * 2f))
            {
                if (!HasOrdered)
                {
                    Order();
                }
                WalkingToPosition = false;
            }
        }
        if (WalkingToCounter)
        {
            if (this.transform.position.x <= -2f)
            {
                WalkingToCounter = false;
                Audio.PlayOneShot(ServeSound);
                //Play Served Animation before leaving
                GhostRenderer.sprite = GhostSprites[1];
                Invoke("Leave", 0.75f);
            }
        }
        if (Leaving)
        {
            if (this.transform.position.x <= -12f)
            {
                ScoreGhost();
            }
        }
    }

    public void Order()
    {
        HasOrdered = true;
        Audio.PlayOneShot(OrderSound);
        MyOrderTicket = Instantiate(OrderPrefab, new Vector3(-9f + ((float)((QueuePosition+1) % 2))*2f, -1f - Mathf.Floor((((float)QueuePosition)-1f)/2f)*2.5f, 0f), Quaternion.identity);
        order = MyOrderTicket.GetComponent<Order>();
        order.ghost = this;
        order.soup = this.soup;
        order.CreateRequirements();
        SpeechBubbleRenderer.enabled = true;
        Invoke("HideSpeech", 0.75f);
    }

    public void HideSpeech()
    {
        if(SpeechBubbleRenderer != null)
        {
            SpeechBubbleRenderer.enabled = false;
        }
    }

    public void MoveToPositionIn(float time)
    {
        if (HasOrdered)
        {
            MyOrderTicket.transform.position = new Vector3(-9f + ((float)((QueuePosition + 1) % 2)) * 2f, -1f - Mathf.Floor((((float)QueuePosition) - 1f) / 2f) * 2.5f, 0f);
        }
        Invoke("MoveToQueuePosition", time);
    }

    public void MoveToQueuePosition()
    {
        WalkingToPosition = true;
        Audio.PlayOneShot(GhostSounds[randGhostSound]);
    }

    public void GetServed()
    {
        WalkingToCounter = true;
        myGame.RemoveGhost(this);
    }

    public void Mutter()
    {
        SpeechBubbleRenderer.enabled = true;
        Audio.PlayOneShot(OrderSound);
        GhostRenderer.sprite = GhostSprites[3];
        Invoke("ReturnNeutral", 0.75f);
    }

    public void ReturnNeutral()
    {
        GhostRenderer.sprite = GhostSprites[0];
        HideSpeech();
    }

    public void Leave()
    {
        GhostRenderer.sprite = GhostSprites[2];
        Leaving = true;
        Audio.PlayOneShot(GhostSounds[randGhostSound]);
    }

    void ScoreGhost()
    {
        myGame.GhostGone(this);
        Destroy(this.gameObject);
        //get your score, maybe spawn new ghost?
        //EndGame();
    }

    void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }

}
