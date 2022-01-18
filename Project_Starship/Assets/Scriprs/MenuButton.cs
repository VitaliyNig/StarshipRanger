using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DevScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}
