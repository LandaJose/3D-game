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

    public GameObject lanternPointLight;
    public GameObject flashlightSpotLight;

    private string rechargeTag = "BatteryRefuel";




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
                lantern.SetActive(false);
                LightChanger("lantern");
                EnableOilCans(true);
                StaminaBar.instance.StartLight(lanternPointLight);
            } else if (selection.gameObject.Equals(flashlight))
            {
                flashlight.SetActive(false);
                LightChanger("flashlight");
                EnableBatteries(true);
                StaminaBar.instance.newBatterObj();
                StaminaBar.instance.StartLight(flashlightSpotLight);
                
            } else if(selection.CompareTag(rechargeTag) && StaminaBar.instance.CheckBattery())
            {
                selection.gameObject.SetActive(false);
                StaminaBar.instance.LightRecharge(25f, true);
            }
        }
    }

    void LightChanger(string portableLight)
    {
        if (portableLight.Equals("lantern"))
        {
            lanternPointLight.SetActive(true);

        }
        else if (portableLight.Equals("flashlight"))
        {
            lanternPointLight.SetActive(false);
            flashlightSpotLight.SetActive(true);
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


}
