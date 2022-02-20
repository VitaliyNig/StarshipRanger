using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngineStart : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            this.gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
