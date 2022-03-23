using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        HangarSpaceship hangarSpaceship = mainCamera.GetComponent<HangarSpaceship>();
        int count = hangarSpaceship.spaceshipPrefabUnlock.Count - 1;
        int id = hangarSpaceship.spaceshipId;
        if(id == 0)
        {
            hangarSpaceship.spaceshipId = count;
        }
        else
        {
            hangarSpaceship.spaceshipId = id - 1;
        }
        hangarSpaceship.Reload();
        hangarSpaceship.Check();
    }

    public void HangarRight()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        HangarSpaceship hangarSpaceship = mainCamera.GetComponent<HangarSpaceship>();
        int count = hangarSpaceship.spaceshipPrefabUnlock.Count - 1;
        int id = hangarSpaceship.spaceshipId;
        if(id == count)
        {
            hangarSpaceship.spaceshipId = 0;
        }
        else
        {
            hangarSpaceship.spaceshipId = id + 1;
        }
        hangarSpaceship.Reload();
        hangarSpaceship.Check();
    }

    public void HangarSelect()
    {
        HangarSpaceship hangarSpaceship = GameObject.Find("Main Camera").GetComponent<HangarSpaceship>();
        PlayerPrefs.SetInt("SpaceshipId", hangarSpaceship.GetID());
        hangarSpaceship.Check();
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void BuyUpgrades()
    {
        Text[] texts = this.GetComponentsInChildren<Text>();
        int count = int.Parse(texts[1].text);
        int money = PlayerPrefs.GetInt("Money");
        if(money >= count)
        {
            PlayerPrefs.SetInt("Money", (money -= count));
            PlayerPrefs.SetInt(this.GetComponentInChildren<Button>().name, (PlayerPrefs.GetInt(this.GetComponentInChildren<Button>().name) + 1));
            GameObject.Find("Main Camera").GetComponent<ShopItems>().UpgradesListReload();
            GameObject.Find("CountMoney").GetComponent<Money>().UpdateMoney();
        }
    }

    public void BuyStarships()
    {
        Text[] texts = this.GetComponentsInChildren<Text>();
        int count = int.Parse(texts[1].text);
        int money = PlayerPrefs.GetInt("Money");
        if(money >= count)
        {
            PlayerPrefs.SetInt("Money", (money -= count));
            PlayerPrefs.SetString(this.GetComponentInChildren<Button>().name, true.ToString());
            GameObject.Find("Main Camera").GetComponent<ShopItems>().StarshipsListReload();
            GameObject.Find("CountMoney").GetComponent<Money>().UpdateMoney();
        }
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void SettingsDev()
    {
        SceneManager.LoadScene("SettingsDev");
    }

    public void PlayerPrefsRemove()
    {
        PlayerPrefs.SetInt("Health", 1);
        PlayerPrefs.SetInt("FireRate", 1);
        PlayerPrefs.SetInt("SpaceshipId", 2);
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.SetInt("Money", 0);
    }

    public void PlayerPrefsDeleteAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefsSettings.Settings();
    }

    public void AddMoney()
    {
        PlayerPrefs.SetInt("Money", 9999);
    }
}
