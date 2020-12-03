using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PicturePuzzle : MonoBehaviour
{
    public GameObject[] puzzle3Cards;
    public GameObject[] tableCards;
    public GameObject[] pickedUpCards = new GameObject[4];
    private bool cardSpawned = false ;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tableCards.Length; i++)
        {
            tableCards[i].SetActive(false);
        }
        for (int i = 0; i < puzzle3Cards.Length; i++)
        {
            puzzle3Cards[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(PortableLightManager.genOn  && !cardSpawned)
        {
            SpawnPuzzle3Cards();
            cardSpawned = true;
        }
        if (keyboard.fKey.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4.0f))
            {
                Transform selection = hit.transform;
                if(selection.gameObject.name.Contains("IncorrectCard"))
                {
                    selection.gameObject.SetActive(false);
                }
                else if (selection.gameObject.name.Equals("CorrectTableCard1")) 
                {
                    pickedUpCards[0] = selection.gameObject;
                    selection.gameObject.SetActive(false);
                }
                else if (selection.gameObject.name.Equals("CorrectTableCard2"))
                {
                    pickedUpCards[1] = selection.gameObject;
                    selection.gameObject.SetActive(false);
                }
                else if (selection.gameObject.name.Equals("CorrectTableCard3"))
                {
                    pickedUpCards[2] = selection.gameObject;
                    selection.gameObject.SetActive(false);
                }
                else if (selection.gameObject.name.Equals("CorrectTableCard4"))
                {
                    pickedUpCards[3] = selection.gameObject;
                    selection.gameObject.SetActive(false);
                }
                else if (selection.gameObject.name.Equals("PuzzleTable"))
                {
                    if (pickedUpCards[0] != null && pickedUpCards[0].name == "CorrectTableCard1" && !tableCards[0].activeSelf)
                    {
                        tableCards[0].SetActive(true);
                    }
                    if (pickedUpCards[1] != null && pickedUpCards[1].name == "CorrectTableCard2" && !tableCards[1].activeSelf)
                    {
                        tableCards[1].SetActive(true);
                    }
                    if (pickedUpCards[2] != null && pickedUpCards[2].name == "CorrectTableCard3" && !tableCards[2].activeSelf)
                    {
                        tableCards[2].SetActive(true);
                    }
                    if (pickedUpCards[3] != null && pickedUpCards[3].name == "CorrectTableCard4" && !tableCards[3].activeSelf)
                    {
                        tableCards[3].SetActive(true);
                    }
                    CheckAllCards();
                }
            }
        }

/*        else if (keyboard.jKey.wasPressedThisFrame)
        {
            for (int i = 0; i < puzzle3Cards.Length; i++)
            {
                puzzle3Cards[i].SetActive(true);
            }
        }*/
    }

    void CheckAllCards()
    {
        if(tableCards[0].activeSelf == true && tableCards[1].activeSelf == true && tableCards[2].activeSelf == true && tableCards[3].activeSelf == true)
        {
            OpenCloseDoors.hasFrontDoorKey = true;
            Debug.Log("Front door key aquired");
        }
    }

    void SpawnPuzzle3Cards()
    {
        OpenCloseDoors.hasSFMasterBedroomKey = true;
        for (int i = 0; i < puzzle3Cards.Length; i++)
        {
            puzzle3Cards[i].SetActive(true);
        }
    }
}
