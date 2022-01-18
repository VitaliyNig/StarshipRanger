using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpawn : MonoBehaviour
{
    public GameObject spaceshipPrefab;
    public Vector3 screenSize;
    public float spawnPosY = 0f;
    
    void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        GameObject spaceshipGO = Instantiate<GameObject>(spaceshipPrefab);
        Vector3 spaceshipPos = Vector3.zero;
        spaceshipPos.z = -screenSize.z + spawnPosY;
        spaceshipGO.transform.position = spaceshipPos;
    }
}
