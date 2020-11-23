using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryPickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private string gasCanTag = "GasCan";
    private string gasCanMainTag = "GasCanMain";
    private PortableLightManager plm;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        plm = GameObject.FindGameObjectWithTag("Player").GetComponent<PortableLightManager>();

    }

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
            if (selection.CompareTag(gasCanTag) || selection.CompareTag(gasCanMainTag))
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        inventory.icons[i] = Instantiate(itemButton, inventory.slots[i].transform, false);
                        inventory.slottedObject[i] = selection.gameObject;
                        selection.gameObject.SetActive(false);
                        break;
                    }
                }
            }
            if (selection.CompareTag(gasCanMainTag))
            {
                plm.EnableGasCans(true);
            }

        }
    }


}
