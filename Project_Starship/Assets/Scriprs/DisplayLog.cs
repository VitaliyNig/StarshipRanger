using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLog : MonoBehaviour
{
    private string log;
    private const int MAXCHARS = 1000;
    private Queue myLogQueue = new Queue();

    void Start()
    {
        Debug.Log("Display Log Active");
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        myLogQueue.Enqueue("\n [" + type + "] : " + logString);
        if (type == LogType.Exception)
            myLogQueue.Enqueue("\n" + stackTrace);
    }

    void Update()
    {
        while (myLogQueue.Count > 0)
            log = myLogQueue.Dequeue() + log;
        if (log.Length > MAXCHARS)
            log = log.Substring(0, MAXCHARS);
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 40;
        GUILayout.Label(log);
    }
}
