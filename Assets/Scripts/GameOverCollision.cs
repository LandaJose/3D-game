using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Crawler" || collider.gameObject.name == "crawler")
        {
            Debug.Log("Game over");
            FindObjectOfType<EndGame>().EndedGame();
            FindObjectOfType<CharacterMovement>().enabled = false;
            FindObjectOfType<ChasePlayer>().enabled = false;
            FindObjectOfType<ViewController>().enabled = false;
        }
    }
}
