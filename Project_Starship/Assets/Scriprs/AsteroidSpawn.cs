using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawn : MonoBehaviour
{
    public AstreroidsLists asteroidsPrefabs = new AstreroidsLists();
    public float spawnRate;
    public float asteroidSpeed;
    private float asteroidCount;
    private Vector3 screenSize;
    private int score;

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

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        Debug.Log("Screen Size: " + screenSize);
        asteroidCount = 1;
        StartCoroutine(SpawnTimer());
        InvokeRepeating("Difficulty", 0.5f, 0.5f);
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnRate);
        for (int i = 0; i < asteroidCount; i++)
        {
            SpawnAsteroid();
        }
        StartCoroutine(SpawnTimer());
    }

    private void SpawnAsteroid()
    {
        int numberList = Random.Range(0, asteroidsPrefabs.asteroidsLists.Count);
        GameObject asteroidGO = Instantiate<GameObject>(asteroidsPrefabs.asteroidsLists[numberList].asteroidPrefab[Random.Range(0, asteroidsPrefabs.asteroidsLists[numberList].asteroidPrefab.Count)]);
        Vector3 asteroidPos = Vector3.zero;
        asteroidPos.x = Random.Range(-screenSize.x, screenSize.x);
        asteroidPos.z = screenSize.z + Random.Range(3f, 7f);
        Transform thisTransform = asteroidGO.transform;
        thisTransform.position = asteroidPos;
        thisTransform.Rotate(float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), float.Parse(Random.Range(0, 360).ToString()), Space.Self);
        asteroidGO.GetComponent<Rigidbody>().AddForce(0f, 0f, -asteroidSpeed, ForceMode.Impulse);
    }

    private void Difficulty()
    {
        GameObject countScore = GameObject.Find("CountScore");
        if (countScore.GetComponent<Score>().GameIsActive == true)
        {
            score = int.Parse(countScore.GetComponent<Text>().text);
            if (score % 5 == 0)
            {
                asteroidSpeed += 0.05f;
                spawnRate -= 0.01f;
                if (spawnRate <= 0)
                {
                    asteroidCount++;
                    spawnRate = 1f;
                }
            }
        }
    }
}
