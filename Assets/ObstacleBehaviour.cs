using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    private void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        enabled = false;
    }

    private void GameStart()
    {
        enabled = true;
    }

    private void GameOver()
    {
        // GetComponent<Rigidbody>().velocity = new Vector3(0,0);
        // Destroy(gameObject, 2);
        enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Obstacle collided with " + col.tag);
        if (col.tag != "Player")
        {
            Debug.Log("Destroying object on collision");
            Destroy(gameObject);
        }
    }
}