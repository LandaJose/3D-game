using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenCloseDoors : MonoBehaviour
{
    public float doorOpenAngle = 90.0f; //Set either positive or negative number to open the door inwards or outwards
    public float openSpeed = 2.0f; //Increasing this value will make the door open faster

    bool open = false;
    bool enter = false;
    public static bool hasSFBathroomKey = false;
    public static bool hasSFMasterBedroomKey = false;
    public static bool hasFlashlightKey = false;
    public static bool hasFrontDoorKey = false;
    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

        if (this.CompareTag("UnlockedDoor") && keyboard.eKey.wasPressedThisFrame && enter)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }
        else if (this.CompareTag("SecondFloorBathroomDoor") && keyboard.eKey.wasPressedThisFrame && enter && hasSFBathroomKey)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }
        else if (this.CompareTag("SecondFloorMasterBedroom") && keyboard.eKey.wasPressedThisFrame && enter && hasSFMasterBedroomKey)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }
        else if (this.CompareTag("FlashlightDoor") && keyboard.eKey.wasPressedThisFrame && enter && hasFlashlightKey)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }
        else if (this.CompareTag("FrontDoor") && keyboard.eKey.wasPressedThisFrame && enter && hasFrontDoorKey)
        {
            Debug.Log("FRONT DOOR OPENED");
            WinGame.gameWon = true;
            //this will set a boolean to display the game over menu in another script
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
