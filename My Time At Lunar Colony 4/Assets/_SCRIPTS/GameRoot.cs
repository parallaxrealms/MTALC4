using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class GameRoot : MonoBehaviour
{
    public static GameRoot current;

    private GameObject playerObject;
    private StarterAssets.StarterAssetsInputs starterInput;
    private StarterAssets.FirstPersonController fpsController;

    [SerializeField]
    private GameObject terminalFullScreen;

    private bool terminalLaunched;

    public GameObject timerObject;
    [SerializeField]
    private TextMeshProUGUI timer_text;
    public float timeLeft = 3600.0f;

    //Buttons

    //NPC Info
    [SerializeField]
    private int currentNPC;
    private List<NPCData> NPCList;
    public NPCData currentNPCData;

    public GameObject NPCPortrait_Object;
    public Sprite NPCPortrait_Sprite;

    public string NPCName;
    public GameObject NPCName_Object;
    private TextMeshProUGUI NPCName_Text;

    public string NPCSpecies;
    public GameObject NPCSpecies_Object;
    private TextMeshProUGUI NPCSpecies_Text;

    public string NPCOccupation;
    public GameObject NPCOccupation_Object;
    private TextMeshProUGUI NPCOccupation_Text;

    public string cargoWeight;
    public GameObject cargoWeight_Object;
    private TextMeshProUGUI cargoWeight_Text;

    public string vehicleID;
    public GameObject vehicle_Object;
    private TextMeshProUGUI vehicle_Text;

    //NPCDialogueText
    public GameObject NPCDialogue_Object;
    private Text NPCDialogue_Text;
    [SerializeField]
    private Font originalFont;
    [SerializeField]
    private Font alienFont1;

    //Credits
    public GameObject credits_Object;
    private TextMeshProUGUI credits_Text;
    public GameObject creditsAdd_Object;
    private TextMeshProUGUI creditsAdd_Text;

    //Strikes
    public GameObject strike1_Object;
    private Toggle strike1_Toggle;
    public GameObject strike2_Object;
    private Toggle strike2_Toggle;
    public GameObject strike3_Object;
    private Toggle strike3_Toggle;

    //ProgressBools

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

        NPCList = new List<NPCData>();

        creditsAdd_Text = creditsAdd_Object.GetComponent<TextMeshProUGUI>();
        creditsAdd_Object.SetActive(false);

        strike1_Toggle = strike1_Object.GetComponent<Toggle>();
        strike2_Toggle = strike2_Object.GetComponent<Toggle>();
        strike3_Toggle = strike3_Object.GetComponent<Toggle>();
    }

    public void InitGame()
    {
        SceneManager.LoadScene("Game");

        LockMouseCursor();
    }

    public void GetNPCSubtitleText()
    {
        NPCDialogue_Object = GameObject.Find("NPCSubtitleText");
        NPCDialogue_Text = NPCDialogue_Object.GetComponent<Text>();
        originalFont = NPCDialogue_Text.font;
    }
    public void ChangeNPCText(int fontToChangeTo)
    {
        if (fontToChangeTo == 0)
        {
            NPCDialogue_Text.font = originalFont;

        }
        else if (fontToChangeTo == 1)
        {
            NPCDialogue_Text.font = alienFont1;
        }
    }


    public static string TimeFormatter(float seconds, bool forceHHMMSS = false)
    {
        float secondsRemainder = Mathf.Floor((seconds % 60) * 100) / 100.0f;
        int minutes = ((int)(seconds / 60)) % 60;
        int hours = (int)(seconds / 3600);

        if (!forceHHMMSS)
        {
            if (hours == 0)
            {
                return System.String.Format("{0:00}:{1:00.00}", minutes, secondsRemainder);
            }
        }
        return System.String.Format("{0}:{1:00}:{2:00}", hours, minutes, secondsRemainder);
    }

    public void UnlockMouseCursor()
    {
        playerObject = GameObject.Find("Player");
        starterInput = playerObject.GetComponent<StarterAssets.StarterAssetsInputs>();
        fpsController = playerObject.GetComponent<StarterAssets.FirstPersonController>();
        terminalFullScreen.SetActive(true);

        if (!terminalLaunched)
        {
            timer_text = timerObject.GetComponent<TextMeshProUGUI>();
            terminalLaunched = false;
        }
        timer_text.text = TimeFormatter(timeLeft, false);


        starterInput.TurnOffCursorLock();
        fpsController.enabled = false;
    }

    public void LockMouseCursor()
    {
        playerObject = GameObject.Find("Player");
        starterInput = playerObject.GetComponent<StarterAssets.StarterAssetsInputs>();
        fpsController = playerObject.GetComponent<StarterAssets.FirstPersonController>();
        if (terminalFullScreen != null)
        {
            terminalFullScreen.SetActive(false);
        }

        starterInput.TurnOnCursorLock();
        fpsController.enabled = true;
    }

    public void SubtractFromTimer(float secondsToSubtract)
    {
        timeLeft -= secondsToSubtract;

        if (timeLeft < 0f)
        {
            timeLeft = 0f;
        }

        timer_text.text = TimeFormatter(timeLeft, false);
    }

    public void DisableButton(GameObject buttonToDisable)
    {
        Button btnComponent = buttonToDisable.GetComponent<Button>();
        btnComponent.interactable = false;
    }

    public void EnableButton(GameObject buttonToEnable)
    {
        Button btnComponent = buttonToEnable.GetComponent<Button>();
        btnComponent.interactable = true;
    }
}