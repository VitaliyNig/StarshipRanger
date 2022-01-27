using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpaceship : MonoBehaviour
{
    public List<GameObject> spaceshipPrefab;
    GameObject spaceshipGO;
    public int spaceshipId = 2;
    public Vector3 spawnPos;
    public Vector3 spawnRotate;

    void Start()
    {
        if(PlayerPrefs.HasKey("SpaceshipId"))
        {
            spaceshipId = PlayerPrefs.GetInt("SpaceshipId");
        }
        else
        {
            PlayerPrefs.SetInt("SpaceshipId", 2);
        }
        Reload();
    }

    public void Reload()
    {
        Destroy(spaceshipGO);
        spaceshipGO = Instantiate<GameObject>(spaceshipPrefab[spaceshipId]);
        spaceshipGO.transform.Rotate(spawnRotate, Space.Self);
        spaceshipGO.transform.position = spawnPos;
    }
}
