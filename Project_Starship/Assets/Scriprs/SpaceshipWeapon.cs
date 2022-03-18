using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spaceshipPrefab;
    public float spawnPosZ = 0f;
    public float bulletSpeed = 0f;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Game")
        {
            float rate = 0.5f - (PlayerPrefs.GetInt("FireRate") * 0.05f);
            InvokeRepeating("SpawnBullet", rate, rate);
        }
    }

    void SpawnBullet()
    {
        GameObject bulletGO = Instantiate<GameObject>(bulletPrefab);
        Vector3 bulletPos = Vector3.zero;
        bulletPos.z = spawnPosZ;
        bulletGO.transform.position = spaceshipPrefab.transform.position + bulletPos;
        bulletGO.GetComponent<Rigidbody>().AddForce(0f, 0f, bulletSpeed, ForceMode.Impulse);
    }
}
