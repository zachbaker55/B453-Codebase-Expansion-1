using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public GameObject GhostPrefab;
    public List<Ghost> SoupLine;
    public float TimeTillGhost = 5f;
    public float LastGhostTime = 0f;
    public SoupPot soup;
    public float LevelTime = 120f;
    public float StartTime;
    public TextMeshPro text;
    public Flicker flames;
    public bool PauseTime;
    public Ghost lastGhost;

    public static int Score = 0;

    public GameObject PopupPrefab;
    public bool LevelStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        ShowIntro();
    }

    void ShowIntro()
    {
        var popup = Instantiate(PopupPrefab, Vector3.zero, Quaternion.identity);
        PopOver pop = popup.GetComponent<PopOver>();
        pop.callback = StartLevel;
        pop.SetText(SharedData.LevelIntros[SharedData.Level-1]);
    }

    void StartLevel()
    {
        StartTime = Time.time;
        NewGhost();
        LevelStarted = true;
        soup.StartLevel();
        flames.Flip();
        soup.bubbles.Flip();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelStarted)
        {
            return;
        }
        if(Time.time > TimeTillGhost + LastGhostTime)
        {
            NewGhost();
        }
        float RemainingTime = LevelTime - (Time.time - StartTime);
        //Debug.Log("Remaining time: " + System.TimeSpan.FromSeconds(RemainingTime).ToString(@"mm\:ss"));
        if(RemainingTime < 0f)
        {
            RemainingTime = 0f;
        }

        if (!PauseTime)
        {
            text.text = "Closing in: " + System.TimeSpan.FromSeconds(RemainingTime).ToString(@"mm\:ss");

            text.text += "\r\nSouls Served: " + SharedData.Score + "/" + SharedData.GoalScores[SharedData.Level - 1];
        }

        if (SharedData.Score >= SharedData.GoalScores[SharedData.Level-1])
        {
            SharedData.levelWon = true;
            PauseTime = true;
            if (string.IsNullOrWhiteSpace(SharedData.TimeRemaining))
            {
                SharedData.TimeRemaining = System.TimeSpan.FromSeconds(RemainingTime).ToString(@"mm\:ss");
            }
        }

        if (RemainingTime <= 0f)
        {
            SharedData.levelWon = false;
            EndGame();
        }
    }

    public void NewGhost()
    {
        if (SoupLine.Count < 4 && (SharedData.Score + SoupLine.Count) < SharedData.GoalScores[SharedData.Level-1])
        {
            var newGhost = Instantiate(GhostPrefab, new Vector3(12f, 2.5f, 0f), Quaternion.identity);
            Ghost ghost = newGhost.GetComponent<Ghost>();
            SoupLine.Add(ghost);
            ghost.QueuePosition = SoupLine.Count;
            ghost.soup = soup;
            ghost.myGame = this;
            ghost.MoveToQueuePosition();
        }
        LastGhostTime = Time.time;
    }

    public void RemoveGhost(Ghost ghost)
    {
        int spot = SoupLine.LastIndexOf(ghost);
        Debug.Log("Removing Ghost At " + spot);
        if(spot < 0)
        {
            return;
        }
        lastGhost = ghost;
        SoupLine.Remove(ghost);
        SharedData.Score++;
        Debug.Log("Current Score: " + SharedData.Score);
        for(int i = spot; i< SoupLine.Count; i++)
        {
            Debug.Log("Updating to have queue position " + (i+1) + " instead of " + SoupLine[i].QueuePosition);
            SoupLine[i].QueuePosition = i+1;
            SoupLine[i].MoveToPositionIn(0.5f + (Random.value * 0.75f));
        }
    }

    public void GhostGone(Ghost ghost)
    {
        if(PauseTime && SoupLine.Count == 0 && lastGhost == ghost)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
