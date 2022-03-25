using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    public GameObject rowUpgradesPrefab;
    public Transform rowsUpgradesParent;
    public GameObject rowStarhipsPrefab;
    public Transform rowsStarhipsParent;
    public List<Sprite> spriteList;

    public class Upgrades
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    [SerializeField]
    List<Upgrades> upgradesList = new List<Upgrades>()
    {
        new Upgrades{ Name = "Health", Count = 100 },
        new Upgrades{ Name = "Fire Rate", Count = 100 },
        new Upgrades{ Name = "Aim Assistance", Count = 100}
    };

    public class Starships
    {
        public int StarshipsID { get; set; }
        public int Count { get; set; }
        public bool Status { get; set; }
    }

    [SerializeField]
    public List<Starships> starshipsList = new List<Starships>()
    {
        new Starships{ StarshipsID = 0, Count = 300, Status = false},
        new Starships{ StarshipsID = 1, Count = 300, Status = false},
        new Starships{ StarshipsID = 2, Count = 300, Status = true},
        new Starships{ StarshipsID = 3, Count = 300, Status = false},
        new Starships{ StarshipsID = 4, Count = 300, Status = false},
        new Starships{ StarshipsID = 5, Count = 300, Status = false}
    };

    private void Start()
    {
        UpgradesList();
        StarshipsList();
    }

    private void UpgradesList()
    {
        foreach (var u in upgradesList)
        {
            GameObject rowUpgradesGo = Instantiate(rowUpgradesPrefab, rowsUpgradesParent);
            Text[] texts = rowUpgradesGo.GetComponentsInChildren<Text>();
            texts[1].text = (u.Count * PlayerPrefs.GetInt(u.Name)).ToString();
            texts[2].text = u.Name;

            Toggle[] toggles = rowUpgradesGo.GetComponentsInChildren<Toggle>();
            for (int c = 0; c < PlayerPrefs.GetInt(u.Name); c++)
            {
                toggles[c].isOn = true;
            }

            Button button = rowUpgradesGo.GetComponentInChildren<Button>();
            button.name = u.Name;
            if (PlayerPrefs.GetInt(u.Name) >= 5)
            {
                button.interactable = false;
                texts[1].text = "‒";
            }
        }
    }

    private void StarshipsList()
    {
        foreach (var s in starshipsList)
        {
            GameObject rowStarhipsGo = Instantiate(rowStarhipsPrefab, rowsStarhipsParent);
            Text[] texts = rowStarhipsGo.GetComponentsInChildren<Text>();
            texts[1].text = s.Count.ToString();
            rowStarhipsGo.GetComponentInChildren<Image>().sprite = spriteList[s.StarshipsID];

            Button button = rowStarhipsGo.GetComponentInChildren<Button>();
            button.name = s.StarshipsID.ToString();
            if (bool.Parse(PlayerPrefs.GetString(s.StarshipsID.ToString())) == true)
            {
                rowStarhipsGo.GetComponentInChildren<Button>().interactable = false;
                texts[1].text = "‒";
            }
        }
    }

    public void UpgradesListReload()
    {
        foreach (Transform child in rowsUpgradesParent.transform)
        {
            Destroy(child.gameObject);
        }
        UpgradesList();
    }

    public void StarshipsListReload()
    {
        foreach (Transform child in rowsStarhipsParent.transform)
        {
            Destroy(child.gameObject);
        }
        StarshipsList();
    }
}