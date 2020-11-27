using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrawlerAnimationChange : MonoBehaviour
{
    private bool isCrawling = false;
    Animator anim;
    private Vector3 currentLocation;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        currentLocation = GameObject.Find("Crawler").transform.position;
        if (keyboard != null)
        {
            if ((StaminaBar.currentStamina <= 0) && !isCrawling)
            {
                anim.SetTrigger("Crawl");
                isCrawling = true;
            }
            else if ((StaminaBar.currentStamina >= 0) && isCrawling && (currentLocation != ChasePlayer.spawnDestination))
            {
                anim.SetTrigger("CrawlToSpawn");
                isCrawling = true;
            }

            if (isCrawling && ((int)currentLocation.x == (int)ChasePlayer.spawnDestination.x) && ((int)currentLocation.y == (int)ChasePlayer.spawnDestination.y) && ((int)currentLocation.z == (int)ChasePlayer.spawnDestination.z))
            {
                anim.SetTrigger("Idle");
                isCrawling = false;
            }
        }
    }
}
