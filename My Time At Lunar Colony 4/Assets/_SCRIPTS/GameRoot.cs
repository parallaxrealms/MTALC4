using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameRoot : MonoBehaviour
{
    public static GameRoot current;

    private GameObject playerObject;
    private StarterAssets.StarterAssetsInputs starterInput;
    private StarterAssets.FirstPersonController fpsController;

    [SerializeField]
    private GameObject terminalFullScreen;

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
    }

    public void InitGame()
    {
        SceneManager.LoadScene("Game");

        playerObject = GameObject.Find("Player");
        starterInput = playerObject.GetComponent<StarterAssets.StarterAssetsInputs>();
        fpsController = playerObject.GetComponent<StarterAssets.FirstPersonController>();
        terminalFullScreen.SetActive(false);
    }

    public void UnlockMouseCursor()
    {
        playerObject = GameObject.Find("Player");
        starterInput = playerObject.GetComponent<StarterAssets.StarterAssetsInputs>();
        fpsController = playerObject.GetComponent<StarterAssets.FirstPersonController>();
        terminalFullScreen.SetActive(true);

        starterInput.TurnOffCursorLock();
        fpsController.enabled = false;
    }

    public void LockMouseCursor()
    {
        playerObject = GameObject.Find("Player");
        starterInput = playerObject.GetComponent<StarterAssets.StarterAssetsInputs>();
        fpsController = playerObject.GetComponent<StarterAssets.FirstPersonController>();
        terminalFullScreen.SetActive(false);

        starterInput.TurnOnCursorLock();
        fpsController.enabled = true;
    }
}