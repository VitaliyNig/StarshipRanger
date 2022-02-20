using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRemove : MonoBehaviour
{
    public ParticleSystem explosionParticlePrefab;
    bool checkRetry = false;

    private void OnCollisionEnter(Collision other) {
        if(checkRetry == false)
        {
            checkRetry = true;
            GameObject thisGO = this.gameObject;
            string colliderTag = other.collider.tag;
            if(colliderTag == "Bullet")
            {
                if(thisGO.tag == "Crystal")
                {
                    GameObject.Find("CountMoney").GetComponent<Money>().countMoney++;
                }
                ParticleSystem.Instantiate(explosionParticlePrefab, thisGO.transform.position, Quaternion.identity).Play();
                Destroy(thisGO);
            }
            else if(colliderTag == "Starship")
            {
                if(GameObject.Find("CountHealth").GetComponent<Health>().countHealth > 1)
                {
                    ParticleSystem.Instantiate(explosionParticlePrefab, thisGO.transform.position, Quaternion.identity).Play();
                    Destroy(thisGO);
                }
            }
            else
            {
                Destroy(thisGO);
            }
        }
    }
}
