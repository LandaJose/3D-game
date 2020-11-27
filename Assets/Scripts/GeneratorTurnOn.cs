using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTurnOn : MonoBehaviour
{
    public AudioClip[] GeneratorAudio;
    public AudioSource audioS;

    public void PlayGeneratorAudio()
    {
        audioS.PlayOneShot(GeneratorAudio[0]);
    }
}
