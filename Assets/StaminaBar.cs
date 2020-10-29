using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public GameObject lightSource;


    private float maxStamina = 100f;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void StartLight(GameObject lightSource)
    {
        this.lightSource = lightSource;
        if (currentStamina  > 0)
        {
            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not Enough Stamina");
        }
    }

    public void LightRecharge(float amount, bool condition)
    {
        Debug.Log(currentStamina);
        if (regen != null)
        {
            StopCoroutine(regen);
        }
        if (condition == true)
        {
            this.lightSource.SetActive(true);
            currentStamina += amount;
            staminaBar.value = currentStamina;
            regen = StartCoroutine(RegenStamina());
        }
        else 
        {
            currentStamina -= .10f;
            staminaBar.value = currentStamina;
        }
    }

    public bool CheckBattery() {
        if (currentStamina <= 75)
        {
            Debug.Log(currentStamina);
            return true;
        }
        else {
            Debug.Log(currentStamina);
            return false;
        }
    }

    public void newBatterObj()
    {
        if (regen != null)
        {
            StopCoroutine(regen);
        }

        
        //this.lightSource.SetActive(true);
        currentStamina = 100;
        staminaBar.value = currentStamina;


        Debug.Log(currentStamina);

         
        
        
    }


    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while (currentStamina > 0)
        {
            currentStamina -= .20f;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }

        if(currentStamina <= 0)
        {
            Debug.Log("Light to turn off: " + lightSource.name);
            lightSource.SetActive(false);
        }
    }


}
