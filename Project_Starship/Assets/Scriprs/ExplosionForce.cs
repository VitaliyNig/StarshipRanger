using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionForce : MonoBehaviour
{
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Game")
        {
            float speed = GameObject.Find("Main Camera").GetComponent<AsteroidSpawn>().asteroidSpeed;
            GameObject thisGO = this.gameObject;
            thisGO.GetComponent<Rigidbody>().AddForce(0f, 0f, -speed, ForceMode.Impulse);
        }
    }
}
