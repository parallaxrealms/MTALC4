using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoot : MonoBehaviour
{
    public static GameRoot current;

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

    void Update()
    {

    }

    public void InitGame()
    {
        SceneManager.LoadScene("Game");
    }
}
