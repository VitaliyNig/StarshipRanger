using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroid : MonoBehaviour
{
    public List<GameObject> asteroidPrefab;
    Rigidbody aRigidbody;
    public float spawnPosX = 0f;
    
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject asteroidGO = Instantiate<GameObject>(asteroidPrefab[Random.Range(0, asteroidPrefab.Count)]);
            Vector3 asteroidPos = Vector3.zero;
            asteroidPos.x = Random.Range(-15f, spawnPosX);
            asteroidPos.y = Random.Range(-15f, 15f);
            asteroidPos.z = Random.Range(20f, 40f);
            asteroidGO.transform.position = asteroidPos;
            asteroidGO.transform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);
            aRigidbody = asteroidGO.GetComponent<Rigidbody>();
            aRigidbody.AddForce(-2f, 0f, 0f, ForceMode.Impulse);
        }
        
        InvokeRepeating("SpawnAsteroid", 0f, 1f);
    }

    void SpawnAsteroid()
    {
        GameObject asteroidGO = Instantiate<GameObject>(asteroidPrefab[Random.Range(0, asteroidPrefab.Count)]);
        Vector3 asteroidPos = Vector3.zero;
        asteroidPos.x = spawnPosX;
        asteroidPos.y = Random.Range(-15f, 15f);
        asteroidPos.z = Random.Range(20f, 40f);
        asteroidGO.transform.position = asteroidPos;
        asteroidGO.transform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);
        aRigidbody = asteroidGO.GetComponent<Rigidbody>();
        aRigidbody.AddForce(-2f, 0f, 0f, ForceMode.Impulse);
    }
}
