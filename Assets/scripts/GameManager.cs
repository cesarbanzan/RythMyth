using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller thBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote=100;
    public int scoreGoodNote = 125;
    public int scorePerfectNote = 150;

    public int currentMultipplier;
    public int multiplierTracker;

    public int[] multiplierThresholds;
    
    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;

    public Text percentText, normalText, goodsText, perfectText, missedText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";

        currentMultipplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                thBS.hasStarted = true;
                theMusic.Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalText.text = "" + normalHits;
                goodsText.text  =goodHits.ToString();
                perfectText.text =perfectHits.ToString();
                missedText.text = " "+missedHits;

                float totalHit= normalHits+goodHits+perfectHits;
                float percentHits = (totalHit / totalNotes) * 100f;

                percentText.text=percentHits.ToString("F1")+"%";
                string rankVal = "F";
                if (percentHits > 40)
                {
                    rankVal = "D";
                    if (percentHits > 55)
                    {
                        rankVal= "C";
                        if(percentHits > 70)
                        {
                            rankVal= "B";
                            if(percentHits > 85)
                            {
                                rankVal= "A";
                                if( percentHits > 95)
                                {
                                    rankVal= "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rankVal;
                finalScoreText.text=currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("HIT ON TIME");
   
        if(currentMultipplier -1< multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultipplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultipplier++;
            }
        }
        multiText.text = "Multiplier: x"+currentMultipplier;
       // currentScore += scorePerNote * currentMultipplier;
           scoreText.text="Score: "+currentScore;
    }
    public void NormalHit()
    {
        NoteHit();
        currentScore += scorePerNote * currentMultipplier;
 
        normalHits++;
    }
    public void GoodHit()
    {
        NoteHit();
        currentScore += scoreGoodNote * currentMultipplier;
   
        goodHits++;
    }
    public void PerfectHit()
    {
        NoteHit();
        currentScore += scorePerfectNote * currentMultipplier;
        perfectHits++;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed");

        missedHits++;

        currentMultipplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultipplier;
    }
}
