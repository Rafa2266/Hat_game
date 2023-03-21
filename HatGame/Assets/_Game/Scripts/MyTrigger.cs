using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MyTrigger : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController=FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if(gameController.currentTime<=0f || gameController.getStartTime()==gameController.currentTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);

        }else if (target.gameObject.CompareTag("Point"))

        {
            if(gameController.gameStarted)
            {
                gameController.score++;
                gameController.scoreView.text = "Score: " + gameController.score;
            }  
            Destroy(this.gameObject);
        }
    }
}
