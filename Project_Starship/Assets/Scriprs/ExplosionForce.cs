using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionForce : MonoBehaviour
{
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "DevScene")
        {
            float speed = GameObject.Find("Main Camera").GetComponent<AsteroidSpawn>().asteroidSpeed;
            this.gameObject.GetComponent<Rigidbody>().AddForce(0f, 0f, -speed, ForceMode.Impulse);
        }
    }
}
