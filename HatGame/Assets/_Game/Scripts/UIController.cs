using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public GameObject panelMainMenu, panelPause,panelGameOver, panelStart;


    // Start is called before the first frame update
    void Start()
    {
        gameController=FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonExitGame()
    {
        //if (input.getkeydown(keycode.escape))
        //{
        //    application.quit();
        //}
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }
    
    public void ButtonStartGame() 
    {
        gameController.Restart();
        panelMainMenu.gameObject.SetActive(false);
        panelStart.gameObject.SetActive(true);

    }
    public void ButtonPauseGame()
    {
        gameController.gameStarted = false;
        gameController.CancelCountdownTime();
        panelStart.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale= 0f;
    }
    public void ButtonResume()
    {
        gameController.gameStarted = true;
        gameController.InvokeCountdownTime();
        panelPause.SetActive(false);
        panelStart.gameObject.SetActive(true);
        Time.timeScale= 1f;
    }
    public void ButtonRestart()
    {
        gameController.Restart();
        panelGameOver.SetActive(false);
        panelStart.gameObject.SetActive(true);
    }
    public void ButtonBackMainMenu() 
    {
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController.ResetGame();
        
    }
}
