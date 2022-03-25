using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpawn : MonoBehaviour
{
    public List<GameObject> spaceshipPrefab;
    public Vector3 screenSize;
    public float spawnPosY = 0f;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        GameObject spaceshipGO = Instantiate<GameObject>(spaceshipPrefab[PlayerPrefs.GetInt("SpaceshipId")]);
        Vector3 spaceshipPos = Vector3.zero;
        spaceshipPos.z = -screenSize.z + spawnPosY;
        spaceshipGO.transform.position = spaceshipPos;
    }
}
