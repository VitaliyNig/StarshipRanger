using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpaceship : MonoBehaviour
{
    public List<GameObject> spaceshipPrefab;
    public int spaceshipId = 2;
    public Vector3 spawnPos;
    public Vector3 spawnRotate;
    private GameObject spaceshipGO;

    private void Start()
    {
        spaceshipId = PlayerPrefs.GetInt("SpaceshipId");
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
