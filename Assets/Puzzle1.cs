using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Puzzle1 : MonoBehaviour
{
    public GameObject[] letters;
    public GameObject[] aces;
    [SerializeField] private GameObject paperUI;
    [SerializeField] private GameObject paperTextObject;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private LayerMask interactLayers;
    private int papersPickedUp = 0;
     

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        if (paperUI.activeSelf && mouse.leftButton.wasPressedThisFrame) //keyboard.eKey.wasPressedThisFrame)
        {
            hidePaperUI();
        }

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        if(Physics.Raycast(ray, out RaycastHit hit, 10f, interactLayers))
        {
            if (mouse.leftButton.wasPressedThisFrame && hit.transform.name.Contains("Note")) // keyboard.eKey.wasPressedThisFrame
            {
                papersPickedUp++;
                hit.transform.gameObject.SetActive(false);
                showPaperUI();
            }
            CheckLetters();

            
        }

        var ray2 = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        if (Physics.Raycast(ray2, out RaycastHit hit2, 20f, interactLayers))
        {
            if (mouse.leftButton.wasPressedThisFrame && hit.transform.name.Contains("Black_PlayingCards"))
            {
                hit2.transform.gameObject.SetActive(false);
                CheckAces();

            }
            
        }


    }

    void CheckLetters()
    {
        if (letters[0].activeSelf == false && letters[1].activeSelf == false && letters[2].activeSelf == false && letters[3].activeSelf == false && letters[4].activeSelf == false)
        {
            OpenCloseDoors.hasFlashlightKey = true;
            Debug.Log("Flash Light Room has been Unlocked");
        }
    }
    public void SpawnLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].SetActive(true);
        }
    }

    public void SpawnAces()
    {
        for (int i = 0; i < aces.Length; i++)
        {
            aces[i].SetActive(true);
        }
    }

    void CheckAces()
    {
        if (aces[0].activeSelf == false && aces[1].activeSelf == false && aces[2].activeSelf == false && aces[3].activeSelf == false)
        {
            OpenCloseDoors.hasSFBathroomKey = true;
            Debug.Log("Second Floor BathRoom has been Unlocked");
        }
    }

    private void showPaperUI()
    {
        playerUI.SetActive(false);
        paperUI.SetActive(true);
        var paperTextMesh = paperTextObject.GetComponent<TMPro.TextMeshProUGUI>();
        var paperText = "";
        switch (papersPickedUp)
        {
            case 1:
                paperText = "HeLlO, You are here for the actions of your Corgi. We are the HOA and your dog has defecated for the last time in our front yards. 1/5 ";
                break;
            case 2:
                paperText = " You must now collect a series of items in order for you to escape and once again see your dog 2/5";
                break;
            case 3:
                paperText = "You will have 2 more sources of light a flash light and generator 3/5 ";
                break;
            case 4:
                paperText = "Have fun 4/5";
                break;
            case 5:
                paperText = "Good Job, you found these pointless letters, now find the aces and remember to check locked doors after completing one of these puzzles.";
                break;
        }
        paperTextMesh.text = paperText;
        Debug.Log(paperText + "<------------");

    }

    private void hidePaperUI()
    {
        playerUI.SetActive(true);
        paperUI.SetActive(false);
    }
}
