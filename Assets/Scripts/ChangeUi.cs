using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ChangeUi : MonoBehaviour
{
    public static int coin_count = 0;
    public TextMeshPro coin_text;

    public static int life_count = 3;
    public TextMeshPro life_text;

    public static int score_count = 0;
    public TextMeshPro score_text;

    private const int MAX_TIME = 400;
    public static int time_count;
    public TextMeshPro time_text;
    private static float start_time;

    private const int COINSCORE = 100;
    private const int KILLSCORE = 200;
    private const int TIMESCORE = 50;
    private const int BRICKSCORE = 10;
    private const int FLAGHEIGHTSCORE = 100;
    private const int SHROOMSCORE = 500;
    
    private static RawImage mushroomDisplay;
    private static RawImage fireflowerDisplay;

    void Start()
    {
        start_time = Time.time;
        time_count = MAX_TIME;
        mushroomDisplay = GameObject.FindGameObjectWithTag("MushroomDisplay").GetComponent<RawImage>();
        fireflowerDisplay = GameObject.FindGameObjectWithTag("FireFlowerDisplay").GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        coin_text.text = $"{coin_count:00}";
        life_text.text = "x"+ life_count;
        float delta_time = Time.time - start_time;
        time_count = MAX_TIME - (int)delta_time;
        time_text.text = "" + time_count;
        score_text.text = $"{score_count:000000}";
    }

    public static void resetUI()
    {
        score_count = 0;
        time_count = MAX_TIME;
        start_time = Time.time;
        setFireflowerDisplay(false);
        setMushroomDisplay(false);
    }

    public static void scoreInc(string scoreType)
    {
        switch(scoreType)
        {
            case "Coin":
                score_count += COINSCORE;
                break;

            case "Brick":
                score_count += BRICKSCORE;
                break;

            case "Kill":
                score_count += KILLSCORE;
                break;

            case "Time":
                score_count += TIMESCORE * (MAX_TIME - time_count);
                break;

            case "Flag":
                score_count += FLAGHEIGHTSCORE;
                break;

            case "Shroom":
                score_count += SHROOMSCORE;
                break;
        }
    }

    public static void setMushroomDisplay(bool state)
    {
        mushroomDisplay.enabled = state;
    }
    
    public static void setFireflowerDisplay(bool state)
    {
        fireflowerDisplay.enabled = state;
    }
}
