using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawn : MonoBehaviour
{
    public List<GameObject> asteroidPrefab;
    Rigidbody aRigidbody;
    public float spawnRate = 0f;
    public float asteroidSpeed = 0f;
    public Vector3 screenSize;
    public int score;
    public float asteroidCount;

    void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        Debug.Log(screenSize);
        InvokeRepeating("SpawnAsteroid", 0f, spawnRate);
        InvokeRepeating("Difficulty", 0.5f, 0.5f);
    }

    void Difficulty()
    {
        score = int.Parse(GameObject.Find("CountScore").GetComponent<Text>().text);
        if(score % 10 == 0)
        {
            asteroidSpeed += 0.05f;
            if(spawnRate > 0.05f)
            {
                spawnRate -= 0.05f;
            }
            else if(0.05f > spawnRate & spawnRate > 0f)
            {
                spawnRate = 0f;
            }
        }
        if(score % 500 == 0)
        {
            spawnRate = 1f;
            asteroidCount++;
        }
    }

    void SpawnAsteroid()
    {
        for(int i = 0; i < asteroidCount; i++)
        {
            GameObject asteroidGO = Instantiate<GameObject>(asteroidPrefab[Random.Range(0, asteroidPrefab.Count)]);
            Vector3 asteroidPos = Vector3.zero;
            asteroidPos.x = Random.Range(-screenSize.x, screenSize.x);
            asteroidPos.z = screenSize.z + Random.Range(4f, 6f);
            asteroidGO.transform.position = asteroidPos;
            asteroidGO.transform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);
            aRigidbody = asteroidGO.GetComponent<Rigidbody>();
            aRigidbody.AddForce(0f, 0f, -asteroidSpeed, ForceMode.Impulse);
        }
    }
}
