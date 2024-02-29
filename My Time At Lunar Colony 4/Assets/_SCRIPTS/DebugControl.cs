using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DebugControl : MonoBehaviour
{
    public static DebugControl current { get; private set; }

    public bool isDebugEnabled = false;
    private string[] debugLines;

    public bool debugMenuEnabled;

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

        debugLines = new string[10];
        for (int i = 0; i < debugLines.Length; i++)
        {
            debugLines[i] = "";
        }
    }
    private void Start()
    {
        SetLine(0, "Debug: ", "ON");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        {
            isDebugEnabled = !isDebugEnabled;
            Debug.Log("DebugEnabled: " + isDebugEnabled);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        {
            QuickStart();
        }

        SetLine(1, "Current FPS: ", FPS.GetCurrentFPS());
    }

    private void OnGUI()
    {
        if (isDebugEnabled)
        {
            float lineHeight = 40f;
            GUIStyle style = new GUIStyle(GUI.skin.label);

            style.fontSize = 30;

            for (int i = 0; i < debugLines.Length; i++)
            {
                Rect debugRect = new Rect(10, 10 + i * lineHeight, 400, lineHeight);
                GUI.Label(debugRect, debugLines[i], style);
            }
        }
    }

    public void SetLine(int lineNumber, string text, string varString)
    {
        if (lineNumber >= 0 && lineNumber < debugLines.Length)
        {
            debugLines[lineNumber] = text + " : " + varString;
        }
    }

    public void SetLine(int lineNumber, string text, int value)
    {
        SetLine(lineNumber, text, value.ToString());
    }

    public void SetLine(int lineNumber, string text, float value)
    {
        SetLine(lineNumber, text, value.ToString());
    }

    public void SetLine(int lineNumber, string text, bool value)
    {
        SetLine(lineNumber, text, value.ToString());
    }

    private void QuickStart()
    {
        GameRoot.current.InitGame();
    }
}