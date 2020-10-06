﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ObjectMovement : MonoBehaviour
{
    public float defaultObjectDistance = 8f;
    public string movableTag = "Movable";
    private Transform _selection;


   


    // Update is called once per frame
    void Update()
    {
  
        var mouse = Mouse.current;

        if (_selection != null) {
            MoveWithMouse();
        }
        if (mouse.leftButton.wasPressedThisFrame) {
            if (_selection == null)
            {
                SelectObject();
            }
            else {
                PlaceObject();
            }
        }
    }


    void SelectObject() {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 25f)) {
            Debug.Log("Touch Object " + hit.transform.gameObject.name);
            Transform selection = hit.transform;
            if (selection.CompareTag(movableTag)) {
                _selection = selection;
            }
        }
    }

    void PlaceObject() {
        _selection = null;
    }

    void MoveWithMouse() {

        _selection.position = new Vector3(transform.position.x + transform.forward.x * 2, transform.position.y + 1f, transform.position.z + transform.forward.z * 2);
    }

  
}
