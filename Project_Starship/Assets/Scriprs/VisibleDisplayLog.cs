using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleDisplayLog : MonoBehaviour
{
    public GameObject displayLog;
    
    public void SnowDisplayLog()
    {
        displayLog.SetActive(true);
        GameObject[] logObjects = GameObject.FindGameObjectsWithTag("DisplayLog");
        if (logObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}