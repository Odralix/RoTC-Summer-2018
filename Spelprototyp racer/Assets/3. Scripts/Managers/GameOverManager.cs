﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public CountDownTimer gameTimer;
    public GameObject playerCube;
    public float restartDelay = 5f;
    public float shadowCatchTime = 20f;
    public GameObject collision;
    public CountUpTimer playerFinalTime;
    public O_HighScore scoreSetter;

    Animator anim;
    float restartTimer;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameTimer.timer <= 10)
        {
            anim.SetTrigger("GameOver");
            //Destroy(playerCube);

            if(gameTimer.timer <= 0)
            {
                restartTimer += Time.deltaTime;
                if (restartTimer >= restartDelay)
                {
                    scoreSetter.addScore(300-playerFinalTime.playerTimer);
                    scoreSetter.SaveScores();
                    SceneManager.LoadScene("NewMainMenu");
                }
            }
        }

        if (gameTimer.timer == 20)
        {
            anim.SetTrigger("ShadowCatch");
        }

        
	}

    public void killFadeFunc()
    {

            anim.SetTrigger("GameOverDeath");
    }

    public void winScreen()
    {
        playerFinalTime.endCheck += 1;
        Debug.Log("WinScreen");
        anim.SetTrigger("Victory");
        restartTimer += Time.deltaTime;
        restartTimer = restartDelay - 5;
        if (restartTimer >= restartDelay)
        {
            scoreSetter.addScore(300-playerFinalTime.playerTimer);
            scoreSetter.SaveScores();
            SceneManager.LoadScene("NewMainMenu");
        }
    }
}
