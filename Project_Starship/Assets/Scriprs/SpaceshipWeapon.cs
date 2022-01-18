using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spaceshipPrefab;
    Rigidbody aRigidbody;
    public float rate = 0f;
    public float spawnPosZ = 0f;
    public float bulletSpeed = 0f;

    void Start()
    {
        InvokeRepeating("SpawnBullet", rate, rate);
    }

    void SpawnBullet()
    {
        GameObject bulletGO = Instantiate<GameObject>(bulletPrefab);
        Vector3 bulletPos = Vector3.zero;
        bulletPos.z = spawnPosZ;
        bulletGO.transform.position = spaceshipPrefab.transform.position + bulletPos;
        aRigidbody = bulletGO.GetComponent<Rigidbody>();
        aRigidbody.AddForce(0f, 0f, bulletSpeed, ForceMode.Impulse);
    }
}
