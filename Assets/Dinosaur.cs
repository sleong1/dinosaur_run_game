using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    public static float distanceTraveled;

    public Vector3 startingPose;
    private float jumpTime = 0f;
    private float lastTime = 0f;
    private bool jumpFlag = false;

    public float jumpHeight = 2.5f;
    
    


    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(startingPose, Quaternion.Euler(Vector3.zero));
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        enabled = false;
    }

    private void GameStart()
    {
        GUIManager.SetDistance(0);
        transform.SetPositionAndRotation(startingPose, Quaternion.Euler(Vector3.zero));
        jumpTime = 0f;
        lastTime = 0f;
        jumpFlag = false;
        distanceTraveled = 0f;
        enabled = true;
    }

    private void GameOver()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && transform.position[1] == 0)
        {
            Debug.Log("Jumping...");
            Jump();
        }
        else
        {
            if ((Time.time - jumpTime) > 0.75f && jumpFlag == true)
            {
                transform.Translate(new Vector3(0f, -jumpHeight));
                jumpFlag = false;
            }
        }

        if (Time.time - lastTime > 0.25f)
        {
            distanceTraveled += 1;
            GUIManager.SetDistance(distanceTraveled);
            lastTime = Time.time;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Collision detected " + col.gameObject.tag);
        GameEventManager.TriggerGameOver();
    }

    void Jump()
    {
        transform.Translate(new Vector3(0f, jumpHeight));
        jumpTime = Time.time;
        jumpFlag = true;
    }
   
}