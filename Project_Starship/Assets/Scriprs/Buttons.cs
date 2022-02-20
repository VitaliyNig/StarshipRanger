using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
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
        GameObject mainCamera = GameObject.Find("Main Camera");
        MenuSpaceship menuSpaceship = mainCamera.GetComponent<MenuSpaceship>();
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
        HangarCheck(mainCamera);
    }

    public void HangarRight()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        MenuSpaceship menuSpaceship = mainCamera.GetComponent<MenuSpaceship>();
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
        HangarCheck(mainCamera);
    }

    public void HangarSelect()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        MenuSpaceship menuSpaceship = mainCamera.GetComponent<MenuSpaceship>();
        PlayerPrefs.SetInt("SpaceshipId", menuSpaceship.spaceshipId);
        HangarCheck(mainCamera);
    }

    void HangarCheck(GameObject mainCamera)
    {
        mainCamera.GetComponent<Hangar>().Check();
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
