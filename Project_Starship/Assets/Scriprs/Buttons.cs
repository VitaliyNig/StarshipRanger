using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DevScene");
    }

    public void GameLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameHangar()
    {
        SceneManager.LoadScene("Hangar");
    }

    public void HangarLeft()
    {
        MenuSpaceship menuSpaceship = GameObject.Find("Main Camera").GetComponent<MenuSpaceship>();
        int count = menuSpaceship.spaceshipPrefab.Count - 1;
        int id = menuSpaceship.spaceshipId;
        if(id == 0)
        {
            menuSpaceship.spaceshipId = count;
        }
        else
        {
            menuSpaceship.spaceshipId = id - 1;
        }
        menuSpaceship.Reload();
    }

    public void HangarRight()
    {
        MenuSpaceship menuSpaceship = GameObject.Find("Main Camera").GetComponent<MenuSpaceship>();
        int count = menuSpaceship.spaceshipPrefab.Count - 1;
        int id = menuSpaceship.spaceshipId;
        if(id == count)
        {
            menuSpaceship.spaceshipId = 0;
        }
        else
        {
            menuSpaceship.spaceshipId = id + 1;
        }
        menuSpaceship.Reload();
    }

    public void HangarSelect()
    {
        MenuSpaceship menuSpaceship = GameObject.Find("Main Camera").GetComponent<MenuSpaceship>();
        PlayerPrefs.SetInt("SpaceshipId", menuSpaceship.spaceshipId);
    }
}
