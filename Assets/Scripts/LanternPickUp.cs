using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LanternPickUp : MonoBehaviour
{
    public AudioClip[] lanternAudio;
    public AudioSource audioS;

    public void PlayLanternAudio()
    {
        audioS.PlayOneShot(lanternAudio[0]);
    }

}
