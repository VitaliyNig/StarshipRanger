using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    Rigidbody aRigidbody;

    void Start()
    {
        float speed = GameObject.Find("Main Camera").GetComponent<AsteroidSpawn>().asteroidSpeed;
        aRigidbody = this.gameObject.GetComponent<Rigidbody>();
        aRigidbody.AddForce(0f, 0f, -speed, ForceMode.Impulse);
    }
}
