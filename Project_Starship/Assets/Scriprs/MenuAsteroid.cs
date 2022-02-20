using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroid : MonoBehaviour
{
    public AstreroidsLists AsteroidsPrefabs = new AstreroidsLists();
    float spawnPosX = 15f;
    
    [System.Serializable]
    public class AsteroidList
    {
        public List<GameObject> asteroidPrefab;
    }
 
    [System.Serializable]
    public class AstreroidsLists
    {
        public List<AsteroidList> asteroidsLists;
    }
    
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
        int numberList = Random.Range(0, AsteroidsPrefabs.asteroidsLists.Count);
        GameObject asteroidGO = Instantiate<GameObject>(AsteroidsPrefabs.asteroidsLists[numberList].asteroidPrefab[Random.Range(0, AsteroidsPrefabs.asteroidsLists[numberList].asteroidPrefab.Count)]);
        asteroidGO.transform.position = asteroidPos;
        asteroidGO.transform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);
        asteroidGO.GetComponent<Rigidbody>().AddForce(-2f, 0f, 0f, ForceMode.Impulse);
    }
}
