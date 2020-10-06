using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform theDest;

    void OnMouseDown()
    {
        //Debug.Log("Clicked ON something");
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;


    }

    void OnMouseUp() {
        Debug.Log("sdasda");
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}

