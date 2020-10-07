using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrawlerAnimationChange : MonoBehaviour
{
    private bool isCrawling = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if (keyboard.tabKey.wasPressedThisFrame && !isCrawling)
            {
                anim.SetTrigger("Crawl");
                isCrawling = true;
            }
            else if (keyboard.tabKey.wasPressedThisFrame && isCrawling)
            {
                anim.SetTrigger("Idle");
                isCrawling = false;
            }
        }
    }
}
