using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangarSpaceship : MonoBehaviour
{
    public List<GameObject> spaceshipPrefab;
    public List<GameObject> spaceshipPrefabUnlock;
    GameObject spaceshipGO;
    public int spaceshipId;
    public Vector3 spawnPos;
    public Vector3 spawnRotate;
    public Text buttonSelect;

    void Start()
    {
        ShopItems shopItems = new ShopItems();
        foreach(var i in shopItems.starshipsList)
        {
            if(bool.Parse(PlayerPrefs.GetString(i.StarshipsID.ToString())) == true)
            {
                spaceshipPrefabUnlock.Add(spaceshipPrefab[i.StarshipsID]);
            }
        }
        spaceshipId = spaceshipPrefabUnlock.FindIndex(item => item.name == spaceshipPrefab[PlayerPrefs.GetInt("SpaceshipId")].name);
        Reload();
    }

    public void Reload()
    {
        Destroy(spaceshipGO);
        spaceshipGO = Instantiate<GameObject>(spaceshipPrefabUnlock[spaceshipId]);
        spaceshipGO.transform.Rotate(spawnRotate, Space.Self);
        spaceshipGO.transform.position = spawnPos;
    }

    public void Check()
    {
        if(spaceshipPrefabUnlock[spaceshipId].name == spaceshipPrefab[PlayerPrefs.GetInt("SpaceshipId")].name)
        {
            buttonSelect.text = "Selected";
        }
        else
        {
            buttonSelect.text = "Select";
        }
    }

    public int GetID()
    {
        return spaceshipPrefab.FindIndex(item => item.name == spaceshipPrefabUnlock[spaceshipId].name);
    }
}