using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{

    private static GUIManager instance;
    public Text gameOverText, instructionsText, distanceText;
    
    void Start()
    {
        instance = this;
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameEventManager.TriggerGameStart();
        }    
    }

    private void GameOver()
    {
        gameOverText.enabled = true;
        instructionsText.enabled = true;
        distanceText.enabled = true;
        enabled = true;
    }

    private void GameStart()
    {
        //SceneManager.LoadScene("MainScene");
        gameOverText.enabled = false;
        instructionsText.enabled = false;
        distanceText.enabled = true;
        enabled = false;
    }

    public static void SetDistance(float distance)
    {
        instance.distanceText.text = "SCORE: " + distance.ToString("f0");
    }

}


