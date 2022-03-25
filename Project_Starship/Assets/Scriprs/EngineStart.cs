using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngineStart : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            GameObject thisGO = this.gameObject;
            thisGO.GetComponent<AudioSource>().Play();
            ParticleSystem[] particleSystems = thisGO.GetComponentsInChildren<ParticleSystem>();
            foreach (var ps in particleSystems)
            {
                ps.Play();
            }
        }
    }
}
