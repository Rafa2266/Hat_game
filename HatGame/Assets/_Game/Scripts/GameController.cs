using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score;
    public int currentTime;
    public GameObject player;
    [SerializeField] private int startTime;
    public bool gameStarted;
    public TextMeshProUGUI timeView;
    public TextMeshProUGUI scoreView;



    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        uiController = FindObjectOfType<UIController>();
        ResetGame();
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
    }

    public void GameOver()
    {
        gameStarted = false;
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
        InvokeRepeating("CountDownTime", 1f, 1f);
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
}
