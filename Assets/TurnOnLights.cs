using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnOnLights : MonoBehaviour
{
    public Light[] lights;
    public GameObject[] emissionLights;
    public Light[] directionalLights;
    public GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        turnOffLights();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(keyboard != null)
        {
            if (keyboard.eKey.wasPressedThisFrame)
            {
                Ray raycast = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                if (Physics.Raycast(raycast, out hit, 4.0f))
                {
                    Transform selection = hit.transform;
                    if (selection.gameObject.Equals(generator))
                    {
                        turnOnLights();
                        StaminaBar.instance.newBatterObj();
                        GameObject[] allLights = new GameObject[lights.Length + emissionLights.Length + directionalLights.Length];
                        lights.CopyTo(allLights, 0);
                        emissionLights.CopyTo(allLights, lights.Length);
                        directionalLights.CopyTo(allLights, lights.Length + emissionLights.Length);
                        StaminaBar.instance.StartLight();

                    }
                }
            }
            else if (keyboard.hKey.wasPressedThisFrame)
            {
                turnOffLights();
            }
        }
    }

    void turnOffLights()
    {
        foreach (Light light in lights)
        {
            if (light.name == "Spot Light")
            {
                light.enabled = false;
            }
        }

        foreach (Light dirLight in directionalLights)
        {
            dirLight.intensity = 0.075f;
        }

        foreach (GameObject emissionLight in emissionLights)
        {
            emissionLight.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }

    void turnOnLights()
    {
        foreach (Light light in lights)
        {
            if (light.name == "Spot Light")
            {
                light.enabled = true;
            }
        }
        foreach (GameObject emissionLight in emissionLights)
        {
            emissionLight.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        foreach (Light dirLight in directionalLights)
        {
            dirLight.intensity = 0.125f;
        }
    }
}
