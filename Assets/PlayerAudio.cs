using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] woodSteps;
    public AudioClip[] stoneSteps;

    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Footsteps()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if(Physics.Raycast(ray, out hit, 1f))
        {
            switch (hit.transform.tag)
            {
                case "WoodFloor":
                    audioS.PlayOneShot(woodSteps[0]);
                    break;

                case "StoneFloor":
                    audioS.PlayOneShot(stoneSteps[0]);
                    break;
            }
        }
    }
}
