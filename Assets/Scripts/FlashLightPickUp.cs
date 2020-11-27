using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPickUp : MonoBehaviour
{
    public AudioClip[] FlashLightAudio;
    public AudioSource audioS;
  
    public void PlayFlashAudio()
    {
        audioS.PlayOneShot(FlashLightAudio[0]);
    }
}
