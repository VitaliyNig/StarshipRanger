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
                    Money money = GameObject.Find("CountMoney").GetComponent<Money>();
                    money.countMoney++;
                    money.UpdateMoney();
                }
                AsteroidDestroy(thisGO);
            }
            else if(colliderTag == "Starship")
            {
                if(GameObject.Find("CountHealth").GetComponent<Health>().countHealth > 1)
                {
                    AsteroidDestroy(thisGO);
                }
            }
            else
            {
                Destroy(thisGO);
            }
        }
    }

    void AsteroidDestroy(GameObject thisGO)
    {
        ParticleSystem ps = ParticleSystem.Instantiate(explosionParticlePrefab, thisGO.transform.position, Quaternion.identity);
        ps.Play();
        ps.GetComponent<AudioSource>().Play();
        Destroy(thisGO);
    }
}
