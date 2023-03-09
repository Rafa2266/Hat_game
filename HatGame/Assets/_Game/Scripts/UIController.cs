using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public GameObject painelMenuPrincipal;

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
        gameController.gameStarted = true;
        painelMenuPrincipal.gameObject.SetActive(false);
    }
}
