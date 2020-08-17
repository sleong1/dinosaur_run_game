using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // private bool activated = false;
    private float delay;
    private float lastActivatedTime = 0;
    private float startTime;
    //private bool startFlag = true;
    public Vector3 startingPosition;

    public Rigidbody cactus;
    public Rigidbody rock;
    public Rigidbody pterodactyl;
    private Rigidbody obstacle;
    private GameObject[] allObstacles;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        enabled = false;
    }


    private void GameOver()
    {
        //startFlag = true;
        enabled = false;
    }

    private void GameStart()
    {
        delay = Random.Range(0.1f, 2.5f);
        startTime = Time.time;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (startFlag == true)
        //{
        //    allObstacles = GameObject.FindGameObjectsWithTag("Finish");
        //    for (int i = allObstacles.Length - 1; i > -1; i--)
        //    {
        //        Destroy(allObstacles[i].GetComponent<Rigidbody>());
        //        Debug.Log("Destroying object in loop");
        //    }
        //    startFlag = false;
        //}
        if (Time.time - lastActivatedTime > delay)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    Debug.Log("Creating a cactus");
                    obstacle = Instantiate(cactus, new Vector3(10f, 0, 0), Quaternion.identity);
                    break;
                case 1:
                    Debug.Log("Creating a pterodactyl");
                    obstacle = Instantiate(pterodactyl, new Vector3(10f, 3f, 0), Quaternion.identity);
                    break;
                case 2:
                    Debug.Log("Creating a rock");
                    obstacle = Instantiate(rock, new Vector3(10f, 0, 0), Quaternion.identity);
                    break;
            }

            obstacle.velocity = new Vector3(-((Time.time - startTime)/10 + 5f), 0f);
            delay = Random.Range(0.5f, 3.5f);
            lastActivatedTime = Time.time;
        }
    }
}