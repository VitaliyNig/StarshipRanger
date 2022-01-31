using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroid : MonoBehaviour
{
    public List<GameObject> asteroidPrefab;
    float spawnPosX = 15f;
    
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            SpawnAsteroid(new Vector3(Random.Range(-spawnPosX, spawnPosX), Random.Range(-15f, 15f), Random.Range(20f, 40f)));
        }
        InvokeRepeating("AsteroidPos", 0f, 1f);
    }

    void AsteroidPos()
    {
        SpawnAsteroid(new Vector3(spawnPosX + 5f, Random.Range(-15f, 15f), Random.Range(20f, 40f)));
    }

    void SpawnAsteroid(Vector3 asteroidPos)
    {
        GameObject asteroidGO = Instantiate<GameObject>(asteroidPrefab[Random.Range(0, asteroidPrefab.Count)]);
        asteroidGO.transform.position = asteroidPos;
        asteroidGO.transform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);
        asteroidGO.GetComponent<Rigidbody>().AddForce(-2f, 0f, 0f, ForceMode.Impulse);
    }
}
