using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FixSafeArea : MonoBehaviour
{
    public GameObject titles;
    public GameObject countScore;
    public GameObject countMoney;
    public GameObject countHealth;
    public GameObject scrollArea;
    public GameObject buttonBack;
    private Scene scene;
    
    private void Awake() 
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Game")
        {
            if(Screen.safeArea.height != Screen.height)
            {
                titles.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
                countScore.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -75, 0);
                countMoney.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250, -25, 0);
                countHealth.GetComponent<RectTransform>().anchoredPosition = new Vector3(250, -25, 0);
            }
        }
    }
}
