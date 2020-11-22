using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LanternPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioS;
    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void OnMouseDown()
    {
        audioS.PlayOneShot(audioS.clip);
    }

}
