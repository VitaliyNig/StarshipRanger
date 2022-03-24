using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnUI : MonoBehaviour
{
    public GameObject explosionParticlePrefab;
    private Health health;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Game")
        {
            health = GameObject.Find("CountHealth").GetComponent<Health>();
        }
    }

    private void OnCollisionEnter(Collision other)
    {   
        health.countHealth--;
        health.UpdateHealth();
        if(health.countHealth == 0)
        {
            ParticleSystem explosionParticle = explosionParticlePrefab.GetComponentInChildren<ParticleSystem>();
            ParticleSystem ps = ParticleSystem.Instantiate(explosionParticle, this.transform.position, Quaternion.identity);
            ps.Play();
            ps.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
            RespawnMenu();
        }
    }

    private void RespawnMenu()
    {
        GameObject.Find("CountScore").GetComponent<Score>().GameIsActive = false;
        GameObject.Find("Canvas").GetComponent<VisibleRespawnUI>().VisibleRespawn();
    }
}