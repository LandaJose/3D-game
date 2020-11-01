using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PortableLightManager : MonoBehaviour
{
    public GameObject lantern;
    public GameObject flashlight;
    public GameObject[] oilCans;
    public GameObject[] batterys;
    public static Boolean genOn;
    public Light[] lights;
    public GameObject[] emissionLights;
    public Light[] directionalLights;

    public GameObject generator;

    //public GameObject mainGasCan;
    //public GameObject[] gasCans;

    public GameObject lanternPointLight;
    public GameObject flashlightSpotLight;

    private string rechargeTag = "BatteryRefuel";

    private string activeLight;

    void Start()
    {
        genOn = false;
        TurnOffAllLights();
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            PickUp();
        }

    }

    void PickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3.0f))
        {
            Transform selection = hit.transform;
            if (selection.gameObject.Equals(lantern))
            {
                activeLight = "lantern";
                lantern.SetActive(false);
                TurnOnLight();
                EnableOilCans(true);
                StaminaBar.instance.StartLight();
            }
            else if (selection.gameObject.Equals(flashlight))
            {
                activeLight = "flashlight";
                flashlight.SetActive(false);
                TurnOnLight();
                EnableBatteries(true);
                StaminaBar.instance.newBatterObj();
                StaminaBar.instance.StartLight();

            }
            else if (selection.CompareTag(rechargeTag) && StaminaBar.instance.CheckBattery())
            {
                selection.gameObject.SetActive(false);
                StaminaBar.instance.LightRecharge(25f, true);
            }
            else if (selection.gameObject.Equals(generator))
            {
                genOn = true;
                activeLight = "house";
                TurnOnLight();
                EnableOilCans(false);
                EnableBatteries(false);
                StaminaBar.instance.setMaxStam();
                StaminaBar.instance.newBatterObj();
                StaminaBar.instance.StartLight();
                
            }
        }
    }

    public void TurnOnLight()
    {
        if (activeLight.Equals("lantern"))
        {
            lanternPointLight.SetActive(true);

        }
        else if (activeLight.Equals("flashlight"))
        {
            lanternPointLight.SetActive(false);
            flashlightSpotLight.SetActive(true);
        }
        else if (activeLight.Equals("house"))
        {
            lanternPointLight.SetActive(false);
            flashlightSpotLight.SetActive(false);

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

    void EnableOilCans(bool active)
    {
        foreach (GameObject oilCan in oilCans)
        {
            oilCan.SetActive(active);
        }
    }

    void EnableBatteries(bool active)
    {
        foreach (GameObject battery in batterys)
        {
            battery.SetActive(active);
            EnableOilCans(false);
        }
    }

    public void TurnOffAllLights()
    {
        lanternPointLight.SetActive(false);
        flashlightSpotLight.SetActive(false);

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

}
