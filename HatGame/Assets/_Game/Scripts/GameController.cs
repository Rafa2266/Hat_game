using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [HideInInspector]public int score, highscore;
    [HideInInspector] public int currentTime;
    public GameObject player;
    [SerializeField] private int startTime;
    [HideInInspector] public bool gameStarted;
    public TextMeshProUGUI timeView;
    public TextMeshProUGUI scoreView;
    public TextMeshProUGUI highscoreView;



    private UIController uiController;

    // Start is called before the first frame update

    //private void Awake()
    //{
    //    PlayerPrefs.DeleteKey("highscore");
    //}
    void Start()
    {
        uiController = FindObjectOfType<UIController>();
        highscore= getHighscore();
        ResetGame();

    }

    public int getStartTime()
    {
        return startTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = false;
        Vector3 aux = player.transform.position;
        player.transform.position = new Vector3(0f, aux.y, aux.z);
        scoreView.text = "";
        highscoreView.text = "HighScore: " + highscore;
    }

    public void GameOver()
    {
        gameStarted = false;
        saveScore();
        uiController.panelStart.SetActive(false);
        uiController.panelGameOver.SetActive(true);
        CancelCountdownTime();
    }
    public void Restart()
    {
        gameStarted = true;
        score = 0;
        currentTime = startTime;
        timeView.text=currentTime.ToString();
        Vector3 aux = player.transform.position;
        player.transform.position = new Vector3(0f, aux.y, aux.z);
        InvokeCountdownTime();
        scoreView.text = "Score: "+score;
    }
    public void InvokeCountdownTime()
    {
        InvokeRepeating("CountDownTime", 0.25f, 1f);
    }
    public void CancelCountdownTime()
    {
        CancelInvoke("CountDownTime");
    }

    public void CountDownTime()
    {
        if (currentTime > 0f)
        {
            currentTime -= 1;
            timeView.text = currentTime.ToString();


        }
        else
        {
            GameOver();
            return;
        }
        
    }
    public void saveScore()
    {
        if(highscore < score)
        {
            highscore= score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
    public int getHighscore()
    {
        return PlayerPrefs.GetInt("highscore");
    }
}
