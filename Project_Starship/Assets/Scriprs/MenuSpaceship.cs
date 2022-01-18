using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpaceship : MonoBehaviour
{
    public GameObject spaceshipPrefab;
    public float spawnPosX = 0f;
    public float spawnPosY = 0f;
    public float spawnPosZ = 0f;
    public float spawnRotate1 = 0f;
    public float spawnRotate2 = 0f;
    public float spawnRotate3 = 0f;

    void Start()
    {
        GameObject asteroidGO = Instantiate<GameObject>(spaceshipPrefab);
        asteroidGO.transform.Rotate(spawnRotate1, spawnRotate2, spawnRotate3, Space.Self);
        asteroidGO.transform.position = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
